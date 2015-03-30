using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Linq;

namespace MonoScratch
{
  public class Events
  {
    public Events ()
    {
      oneShotUpdates_ = new ConcurrentQueue<Action> ();
      continuousUpdates_ = new ConcurrentBag<Action<KeyboardState>> ();
      messageHandlers_ = new ConcurrentDictionary<string, ConcurrentBag<MessageHandler>> ();

      keyMapping_ = new Dictionary<Key, Microsoft.Xna.Framework.Input.Keys> ();
      keyMapping_ [Key.UpArrow] = Keys.Up;
      keyMapping_ [Key.DownArrow] = Keys.Down;
      keyMapping_ [Key.RightArrow] = Keys.Right;
      keyMapping_ [Key.LeftArrow] = Keys.Left;
      keyMapping_ [Key.Space] = Keys.Space;

      ThreadPool.SetMinThreads(20,20);
    }

    public Event WhenGreenFlagClicked { get { return new OneShotEvent(this); } }

    public Event WhenKeyPressed(Key key) { return new ContinuousEvent(this, keyMapping_[key]); }

    public Event WhenIReceive (string message) { return new MessageEvent (this, message); }

    public enum Key
    {
      UpArrow,
      DownArrow,
      RightArrow,
      LeftArrow,
      Space
    }

    public void Process ()
    {
      var keyboard = Keyboard.GetState ();
      Action oneShotAction;
      while (oneShotUpdates_.TryDequeue(out oneShotAction)) {
        oneShotAction.BeginInvoke (null,null);
      }
      foreach (var continuousAction in continuousUpdates_) {
        continuousAction(keyboard);
      }
    }

    public void Enqueue(Action action)
    {
      oneShotUpdates_.Enqueue (action);
    }
    
    public void Add(Action<KeyboardState> action)
    {
      continuousUpdates_.Add (action);
    }
    
    public void Broadcast (string message)
    {
      ConcurrentBag<MessageHandler> handlers;
      if (!messageHandlers_.TryGetValue (message, out handlers))
        return;
      foreach (var handler in handlers) {
        Action action = () =>
        {
          handler.Started.Set();
          handler.Action();
        };
        action.BeginInvoke (null,null);
      }
      WaitHandle.WaitAll(handlers.Select (h => h.Started).ToArray ());
   }

    public void AddMessageHandler (string message, Action action)
    {
      ConcurrentBag<MessageHandler> handlers;
      if (!messageHandlers_.TryGetValue (message, out handlers)) {
        handlers = new ConcurrentBag<MessageHandler> ();
        messageHandlers_ [message] = handlers;
      }
      handlers.Add (new MessageHandler(action));
    }

    ConcurrentQueue<Action> oneShotUpdates_;
    ConcurrentDictionary<string,ConcurrentBag<MessageHandler>> messageHandlers_;
    ConcurrentBag<Action<KeyboardState>> continuousUpdates_;
    Dictionary<Key,Microsoft.Xna.Framework.Input.Keys> keyMapping_;

    class MessageHandler
    {
      public MessageHandler (Action action)
      {
        Action = action;
        Started = new AutoResetEvent(false);
      }
      public AutoResetEvent Started { get; private set; }
      public Action Action { get; private set; }
    }
  }
}


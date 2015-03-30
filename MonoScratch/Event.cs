using System;
using Microsoft.Xna.Framework.Input;

namespace MonoScratch
{
  public interface Event
  {
    void Do(Action action);
  }

  public class OneShotEvent : Event
  {
    public OneShotEvent (Events events)
    {
      events_ = events;
    }

    public void Do (Action action)
    {
      events_.Enqueue (action);
    }

    private Events events_;
  }

  public class ContinuousEvent : Event
  {
    public ContinuousEvent (Events events, Keys key)
    {
      events_ = events;
      key_ = key;
    } 

    public void Do (Action action)
    {
      events_.Add (
        keyboard => {
          if (keyboard.IsKeyDown (key_))
            action();
      }
      );
    }

    private Events events_;
    private Keys key_;
  }
  
  public class MessageEvent : Event
  {
    public MessageEvent (Events events, string message)
    {
      events_ = events;
      message_ = message;
    }

    public void Do (Action action)
    {
      events_.AddMessageHandler (message_, action);
    }

    private Events events_;
    private string message_;
  }
}


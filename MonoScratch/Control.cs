using System;
using System.Reflection;

namespace MonoScratch
{
  public class Control
  {
    public Control (Sprite sprite)
    {
      sprite_ = sprite;
    }

    public void Wait (double seconds)
    {
      System.Threading.Thread.Sleep (TimeSpan.FromSeconds (seconds));
    }

    public void CreateClone ()
    {
      var clone = sprite_.Clone ();
      clone.Game.QuickAdd (clone);
      Action action = () => onCloneStart_.Invoke (clone,null);
      clone.Events.Enqueue (action);
    }
    
    public Event WhenStartingAsClone {
      get {
        return new CloneEvent(this);
      }
    }
   
    public class CloneEvent : Event
    {
      public CloneEvent (Control control)
      {
        control_ = control;
      }

      public void Do (Action action)
      {
        control_.onCloneStart_ = action.Method;
      }

      private Control control_;
    }

    private MethodInfo onCloneStart_;
    private Sprite sprite_;
  }
}


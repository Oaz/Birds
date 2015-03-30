using System;

namespace MonoScratch
{
  public class Looks
  {
    public Looks (Sprite sprite)
    {
      sprite_ = sprite;
    }

    public void Show ()
    {
      sprite_.IsVisible = true;
    }

    public void Hide ()
    {
      sprite_.IsVisible = false;
    }

    public void SwitchCostumeTo (string name)
    {
      sprite_.Costumes.SwitchTo (name);
    }

    private Sprite sprite_;
  }
}


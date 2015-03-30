using System;

namespace MonoScratch
{
  public class Data
  {
    public Data (Sprite sprite)
    {
      sprite_ = sprite;
    }

    public Variable<T> MakeVariable<T> (string name, float x, float y)
    {
      var variable = new Variable<T> (name, x , y);
      sprite_.AddSidekick (variable);
      return variable;
    }

    private Sprite sprite_;
  }
}


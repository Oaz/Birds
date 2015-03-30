using System;
using MonoScratch;

namespace Birds
{
  public class Murs : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/1.png",480,360);
      Motion.PositionX = 1;
      Motion.PositionY = -1;
    }
  }
}


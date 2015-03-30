using System;
using MonoScratch;

namespace Birds
{
  public class PlafondEtSol : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/2.png",480,360);
      Motion.PositionX = -1;
      Motion.PositionY = 0;
    }
  }
}


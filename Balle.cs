using System;
using MonoScratch;

namespace Birds
{
  public class Balle : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/6.png",11,13);
      Motion.PositionX = -47;
      Motion.PositionY = 8;
      Events.WhenGreenFlagClicked.Do (QuandLeDrapeauVertEstCliqué);
      Events.WhenIReceive ("balle touché").Do (QuandJeReçoisBalleTouché); 
    }

    void QuandLeDrapeauVertEstCliqué ()
    {
      Looks.Show ();
    }

    void QuandJeReçoisBalleTouché ()
    {
      Looks.Hide ();
      Control.Wait (2);
      Motion.PositionX = Random (-160, 160);
      Motion.PositionY = Random (-100, 100);
      Looks.Show ();
    }
  }
}


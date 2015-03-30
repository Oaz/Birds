using System;
using MonoScratch;

namespace Birds
{
  public class PiqueBas : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/4.png",25,51);
      Motion.PositionX = 60;
      Motion.PositionY = -161;
      Events.WhenGreenFlagClicked.Do (QuandLeDrapeauVertEstCliqué);
      Control.WhenStartingAsClone.Do (Avancer);
    }

    void QuandLeDrapeauVertEstCliqué ()
    {
      Motion.PositionX = -143;
      Motion.PositionY = -161;
      Control.CreateClone ();
      Motion.PositionX = 0;
      Motion.PositionY = -161;
      Control.CreateClone ();
      Motion.PositionX = 137;
      Motion.PositionY = -161;
      Avancer ();
    }

    void Avancer ()
    {
      for (;;)
      {
        Control.Wait (3);
        Motion.PositionX += 40;
        if (Motion.PositionX > 200)
        {
          Motion.PositionX = -180;
        }
        if (Random (1, 10) > 5)
        {
          Looks.Show ();
        }
        else
        {
          Looks.Hide ();
        }
      }
    }
  }
}


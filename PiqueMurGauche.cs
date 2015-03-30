using System;
using MonoScratch;

namespace Birds
{
  public class PiqueMurGauche : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/5.png",32,58);
      Motion.PositionX = -207;
      Motion.PositionY = -75;
      Events.WhenGreenFlagClicked.Do (QuandLeDrapeauVertEstCliqué);
      Control.WhenStartingAsClone.Do (Avancer);
    }

    void QuandLeDrapeauVertEstCliqué ()
    {
      Motion.PositionX = -207;
      Motion.PositionY = -60;
      Control.CreateClone ();
      Motion.PositionX = -207;
      Motion.PositionY = 50;
      Avancer ();
    }

    void Avancer ()
    {
      for (;;)
      {
        Control.Wait (3);
        Motion.PositionY += 25;
        if (Motion.PositionY > 150)
        {
          Motion.PositionY = -150;
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


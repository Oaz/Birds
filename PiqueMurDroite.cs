using System;
using MonoScratch;

namespace Birds
{
  public class PiqueMurDroite : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("costume1","Graphics/3.png",24,47);
      Motion.PositionX = 200;
      Motion.PositionY = -75;
      Events.WhenGreenFlagClicked.Do (QuandLeDrapeauVertEstCliqué);
      Control.WhenStartingAsClone.Do (Avancer);
    }

    void QuandLeDrapeauVertEstCliqué ()
    {
      Motion.PositionX = 200;
      Motion.PositionY = -60;
      Control.CreateClone ();
      Motion.PositionX = 200;
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


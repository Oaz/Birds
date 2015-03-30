using System;
using MonoScratch;

namespace Birds
{
  class Oiseau : Sprite
  {
    public override void Initialize ()
    {
      Costumes.Add ("gauche","Graphics/7.png",49,30);
      Costumes.Add ("droite","Graphics/8.png",37,31);
      Motion.PositionX = 30;
      Motion.PositionY = -129;
      point = Data.MakeVariable<float>("point",1,2);
      Events.WhenGreenFlagClicked.Do (QuandLeDrapeauVertEstCliqué);
      Events.WhenKeyPressed(Events.Key.Space).Do (QuandLaToucheEspaceEstPressée);
    }

    float vitesseX;
    float vitesseY;
    float gameOver;
    Variable<float> point;

    void QuandLaToucheEspaceEstPressée ()
    {
      vitesseY = 15;
    }

    void QuandLeDrapeauVertEstCliqué()
    {
      point.Value = 0;
      gameOver = 0;
      Motion.PositionX = -10;
      Motion.PositionY = -124;
      vitesseX = 5;
      Looks.SwitchCostumeTo ("droite");
      vitesseY = 20;
      while( !(gameOver == 1) )
      {
        Control.Wait (0.04);
        Motion.PositionX += vitesseX;
        Motion.PositionY += vitesseY;
        if (Sensing.Touching ("PiqueBas") || Sensing.Touching ("PiqueMurDroite") || Sensing.Touching ("PiqueMurGauche"))
        {
          gameOver = 1;
        }
        if (Sensing.Touching ("Murs"))
        {
          vitesseX = 0-vitesseX;
          if (vitesseX > 0) {
            Looks.SwitchCostumeTo ("droite");
          } else {
            Looks.SwitchCostumeTo ("gauche");
          }
          point.Value += 1;
        }
        if (Sensing.Touching ("PlafondEtSol"))
        {
          Motion.PositionY += 0-vitesseY;
          vitesseY = 0-vitesseY/1.5f;
        }
        vitesseY += -1;
        if (Sensing.Touching ("Balle"))
        {
          point.Value += 5;
          Events.Broadcast ("balle touché");
        }
      }
    }
  }
}


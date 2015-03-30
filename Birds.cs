using System;
using System.Collections.Generic;
using MonoScratch;

namespace Birds
{
  class Birds : Game
  {
    protected override void Load ()
    {
      Add (new Oiseau ());
      Add (new Murs ());
      Add (new PlafondEtSol ());
      Add (new PiqueBas ());
      Add (new PiqueMurDroite ());
      Add (new PiqueMurGauche ());
      Add (new Balle ());
    }

  }
}


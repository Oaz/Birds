using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace MonoScratch
{
  public class Sprite : Drawable
  {
    public Sprite ()
    {
      Costumes = new Costumes ();
      Looks = new Looks (this);
      Motion = new Motion (this);
      Control = new Control (this);
      Sensing = new Sensing (this);
      Data = new Data (this);
      random_ = new System.Random ();
      IsVisible = true;
      sidekicks_ = new List<Drawable> ();
    }

    public Costumes Costumes { get; private set; }
    public Looks Looks { get; private set; }
    public Motion Motion { get; private set; }
    public Events Events { get; private set; }
    public Control Control { get; private set; }
    public Sensing Sensing { get; private set; }
    public Data Data { get; private set; }

    public Game Game { get; private set; }

    public override void LoadInto (Game game)
    {
      Game = game;
      Motion.DefineScreen (game.Graphics);
      Events = game.Events;
      Costumes.LoadFrom (game.Content);
      Initialize ();
    }
    
    public virtual void Initialize ()
    {
    }

    public override void Draw (SpriteBatch spriteBatch)
    {
      if (IsVisible) {
        spriteBatch.Draw (
          Costumes.Current.Texture, Motion.PositionVector, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f
        );
      }
      foreach (var sidekick in sidekicks_)
        sidekick.Draw (spriteBatch);
    }

    public Sprite Clone()
    {
      var clone = Activator.CreateInstance (GetType ()) as Sprite;
      clone.Game = Game;
      clone.Events = Events;
      clone.Costumes = Costumes.CloneFor(clone);
      clone.Looks = new Looks (clone);
      clone.Control = new Control (clone);
      clone.Sensing = new Sensing (clone);
      clone.Motion = Motion.CloneFor(clone);
      return clone;
    }

    public void AddSidekick(Drawable sidekick)
    {
      sidekick.LoadInto (Game);
      sidekicks_.Add (sidekick);
    }

    public bool IsVisible { get; set; }

    public int Random(int min, int max)
    {
      return random_.Next (min, max);
    }

    private Random random_;
    private List<Drawable> sidekicks_;

  }
}


using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoScratch
{
  public class Variable<T> : Drawable
  {
    public Variable (string name, float x, float y)
    {
      Name = name;
      vector_ = new Vector2 (x, y);
    }

    public T Value { get; set; }

    public override void LoadInto (Game game)
    {
      game_ = game;
    }

    public override void Draw (SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString (game_.Font, Name+": "+Value.ToString(), vector_, Color.Black );
    }

    private Game game_;
    private Vector2 vector_;
  }
}


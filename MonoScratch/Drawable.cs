using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoScratch
{
  public abstract class Drawable
  {
    public string Name { get; set; }
    
    public abstract void LoadInto (Game game);
    public abstract void Draw (SpriteBatch spriteBatch);
  }
}


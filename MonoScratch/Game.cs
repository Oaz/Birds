using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace MonoScratch
{
  public class Game : Microsoft.Xna.Framework.Game
  {
    public Game ()
    {
      Graphics = new GraphicsDeviceManager (this);
      Content.RootDirectory = "Content";              
      Graphics.IsFullScreen = false; 
      Events = new Events ();
    }

    protected override void LoadContent ()
    {
      Graphics.PreferredBackBufferWidth = 960;
      Graphics.PreferredBackBufferHeight = 720;
      Graphics.ApplyChanges();

      spriteBatch = new SpriteBatch (GraphicsDevice);

      drawables_ = new ConcurrentBag<Drawable> ();
      Load();

      Font = Content.Load<SpriteFont>("Miramonte");
    }

    public SpriteFont Font { get; private set; }

    protected virtual void Load()
    {
    }
 
    public void Add(Sprite sprite)
    {
      QuickAdd (sprite);
      sprite.LoadInto (this);
    }
    
    public void QuickAdd(Sprite sprite)
    {
      sprite.Name = sprite.GetType ().Name;
      drawables_.Add (sprite);
    }

    public IEnumerable<Sprite> FindSprite (string name)
    {
      return drawables_.Where (d => d.Name == name).Cast<Sprite>(); 
    }

    protected override void Update (GameTime gameTime)
    {
      if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
        Exit ();
      }

      Events.Process ();

      base.Update (gameTime);
    }

    protected override void Draw (GameTime gameTime)
    {
      Graphics.GraphicsDevice.Clear (Color.White);
    
      spriteBatch.Begin(SpriteSortMode.BackToFront);
      foreach(var drawable in drawables_)
        drawable.Draw(spriteBatch);
      spriteBatch.End();
            
      base.Draw (gameTime);
    }

    public GraphicsDeviceManager Graphics { get; private set; }
    public Events Events { get; private set; }

    private SpriteBatch spriteBatch;
    private ConcurrentBag<Drawable> drawables_;

  }
}


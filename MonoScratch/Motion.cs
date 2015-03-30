using System;
using Microsoft.Xna.Framework;

namespace MonoScratch
{
  public class Motion
  {
    public Motion (Sprite sprite)
    {
      sprite_ = sprite;
    }

    public void DefineScreen (GraphicsDeviceManager graphics)
    {
      graphics_ = graphics;
      screenWidth_ = graphics_.PreferredBackBufferWidth;
      halfScreenWidth_ = screenWidth_ / 2;
      screenHeigth_ = graphics_.PreferredBackBufferHeight;
      halfScreenHeight_ = screenHeigth_ / 2;
    }

    public Motion CloneFor (Sprite newSprite)
    {
      var motion = new Motion (newSprite);
      motion.DefineScreen (graphics_);
      motion.PositionX = PositionX;
      motion.PositionY = PositionY;
      return motion;
    }

    public Vector2 PositionVector { get; private set; }
    public Rectangle PositionRectangle { get; private set; }

    public float PositionX
    {
      get
      {
        return x_;
      }
      set
      {
        x_ = value;
        UpdatePositionVector ();
      }
    }
    private float x_;

    public float PositionY
    {
      get
      {
        return y_;
      }
      set
      {
        y_ = value;
        UpdatePositionVector ();
      }
    }
    private float y_;

    void UpdatePositionVector ()
    {
      var currentCostume = sprite_.Costumes.Current;
      var x = (int)(halfScreenWidth_ + x_ * 2 - currentCostume.CenterX);
      var y = (int)(halfScreenHeight_-y_*2-currentCostume.CenterY);
      PositionVector = new Vector2(x, y);
      PositionRectangle = new Rectangle (x, y, currentCostume.Texture.Width, currentCostume.Texture.Height);
    }

    private GraphicsDeviceManager graphics_;
    private int screenWidth_;
    private int halfScreenWidth_;
    private int screenHeigth_;
    private int halfScreenHeight_;
    private Sprite sprite_;
  }
}


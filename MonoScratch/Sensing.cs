using System;

namespace MonoScratch
{
  public class Sensing
  {
    public Sensing (Sprite sprite)
    {
      sprite_ = sprite;
    }

    public bool Touching (string otherSpriteName)
    {
      var otherSprites = sprite_.Game.FindSprite (otherSpriteName);
      foreach(var otherSprite in otherSprites)
      {
        if (Touching (otherSprite))
          return true;
      }
      return false;
    }

    public bool Touching (Sprite otherSprite)
    {
      if (!sprite_.IsVisible || !otherSprite.IsVisible)
        return false;
      var myCostume = sprite_.Costumes.Current;
      var otherCostume = otherSprite.Costumes.Current;
      var myRectangle = sprite_.Motion.PositionRectangle;
      var otherRectangle = otherSprite.Motion.PositionRectangle;
      if (!myRectangle.Intersects (otherRectangle))
        return false;

      var deltaX = otherRectangle.X - myRectangle.X;
      var deltaY = otherRectangle.Y - myRectangle.Y;

      for (int y=0; y<myCostume.Texture.Height; y++)
      {
        var otherY = y - deltaY;
        if (otherY < 0 || otherY >= otherCostume.Texture.Height)
          continue;
        for (int x=0; x<myCostume.Texture.Width; x++)
        {
          var myColor = myCostume.Color (x, y);
          if (myColor.A == 0)
            continue;
          var otherX = x - deltaX;
          if (otherX < 0 || otherX >= otherCostume.Texture.Width)
            continue;
          var otherColor = otherCostume.Color (otherX, otherY);
          if (otherColor.A == 0)
            continue;
          return true;
        }
      }

      return false;
    }

    private Sprite sprite_;
  }
}


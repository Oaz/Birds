using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoScratch
{
	public class Costume
	{
    public Costume (ContentManager content, string name, string path, float centerX, float centerY)
    {
      Name = name;
      path_ = path;
      CenterX = centerX;
      CenterY = centerY;

      Texture = content.Load<Texture2D>(path_);

      colors_ = new Color[Texture.Width*Texture.Height];
      Texture.GetData (colors_);
    }

    public Color Color(int x, int y)
    {
      return colors_[x+y*Texture.Width];
    }

    public string Name { get; private set; }
    public Texture2D Texture { get; private set; }
    public float CenterX { get; private set; }
    public float CenterY { get; private set; }

    private string path_;
    private Color[] colors_;
	}
}


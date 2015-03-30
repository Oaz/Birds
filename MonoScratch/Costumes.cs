using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace MonoScratch
{
  public class Costumes
  {
    public Costumes ()
    {
      costumes_ = new List<Costume> ();
    }

    public void Add(string name, string path, float centerX, float centerY)
    {
      costumes_.Add (new Costume (contentManager_, name, path, centerX, centerY));
      Current = costumes_.First ();
    }

    public void SwitchTo (string name)
    {
      Current = costumes_.First(c => c.Name == name);
    }

    public void LoadFrom (ContentManager content)
    {
      contentManager_ = content;
    }

    public Costumes CloneFor (Sprite clone)
    {
      var costumes = new Costumes ();
      costumes.costumes_ = costumes_;
      costumes.Current = Current;
      return costumes;
    }

    public Costume Current { get; private set; }

    private List<Costume> costumes_;
    private ContentManager contentManager_;
  }
}


using System;

namespace Birds
{
  static class Program
  {
    [STAThread]
    static void Main ()
    {
      var game = new Birds ();
      game.Run ();
    }
  }
}

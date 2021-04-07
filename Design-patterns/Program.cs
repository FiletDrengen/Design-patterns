using System;

namespace Design_patterns
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var game = GameWorld.Instance)
                game.Run();
        }
    }
}
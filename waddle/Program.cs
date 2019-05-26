using System;

namespace waddle {
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GF.GameRun(new InGameScene()))
                game.Run();
        }
    }
#endif
}

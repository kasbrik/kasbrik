using System;

namespace Kasbrik
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KasbrikGame game = new KasbrikGame())
            {
                game.Run();
            }
        }
    }
#endif
}


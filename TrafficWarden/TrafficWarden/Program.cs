using System;
using TrafficWarden.source;

namespace TrafficWarden
{
#if WINDOWS || XBOX
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            using (Control game = new Control())
            {
                game.Run();
            }
        }
    }
#endif
}
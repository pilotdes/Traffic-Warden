using System;
using TrafficWarden.source;

namespace TrafficWarden
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Control game = new Control())
            {
                OutputLogging.initOutputting();
                OutputLogging.writeOutput("Starting Application");
                game.Exiting += GameOnExiting;
                game.Run();
            }
        }

        private static void GameOnExiting(object sender, EventArgs eventArgs)
        {
            OutputLogging.writeOutput("Closing Application");
        }
    }
#endif
}


using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Data;
using NUnit.Framework;

namespace TrafficWarden.source
{
    /// <summary>
    ///     The alternate thread that handles the output/error logging,
    ///     freeing up CPU power on the main thread that should be reserved for
    ///     the main game code
    /// </summary
    internal class OutputLogging
    {
        public static void initOutputting()
        {
            if (File.Exists("Output.txt"))
            {
                // Use a try block to catch IOExceptions, to 
                // handle the case of the file already being 
                // opened by another process.
                try
                {
                    File.Delete("Output.txt");
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            using (var file = new StreamWriter("Output.txt", true))
            {
                file.WriteLine(DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString());
            }
        }

        public static void writeOutput(string output)
        {
            ThreadStart childref = new ThreadStart(delegate
            {
                Thread.BeginCriticalRegion();
                using (var file = new StreamWriter("Output.txt", true))
                {
                    file.WriteLine(DateTime.Now.ToLongTimeString() + " -- " + output);
                }
                Thread.EndCriticalRegion();
            });
            Thread childThread = new Thread(childref);
            childThread.Start();
        }
    }
}
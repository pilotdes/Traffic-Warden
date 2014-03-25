using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TrafficWarden.source
{
    /// <summary>
    /// The alternate thread that handles the output/error logging,
    /// freeing up CPU power on the main thread that should be reserved for
    /// the main game code
    /// </summary
    class OutputLogging
    {
        public static void initOutputting()
        {

            if (System.IO.File.Exists("Output.txt"))
            {
                // Use a try block to catch IOExceptions, to 
                // handle the case of the file already being 
                // opened by another process. 
                try
                {
                    System.IO.File.Delete("Output.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Output.txt", true))
            {
                file.WriteLine(DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString());
            }
        }

        public static void writeOutput(string output)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Output.txt", true))
            {
                file.WriteLine(DateTime.Now.ToLongTimeString() + " -- " + output);
            }

            //outWriter.WriteLine(DateTime.Now.ToLongTimeString() + " " + output);
        }
    }
}

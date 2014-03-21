using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingLLib
{
    public class Report
    {
        protected static UnhandledExceptionEventHandler handler;

        public static void InitReporting()
        {
            handler =
new UnhandledExceptionEventHandler(Target)
        }

        private static void Target(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            printToLog((sender as Exception), unhandledExceptionEventArgs);
            outWriter.WriteLine();
            PrintToOutput("**********EXCEPTION**********");
            PrintToOutput("See ErrorLog For Details");
            outWriter.WriteLine();
            Exit();
        }

        private static void WriteErrorLog()
        {
            
        }
        public static void EndReporting()
        {
            
        }
    }
}

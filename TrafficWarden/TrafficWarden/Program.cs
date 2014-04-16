using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Control = TrafficWarden.source.Control;

namespace TrafficWarden
{
#if WINDOWS || XBOX
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            try
            {
                using (Control game = new Control())
                {
                    game.Run();
                }
            }
                #region Catch Section

            catch (Exception e)
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
                    catch (IOException io)
                    {
                        Console.WriteLine(io.Message);
                        return;
                    }
                }
                using (var file = new StreamWriter("ErrorLog.txt", true))
                {
                    file.WriteLine(DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString());
                    file.WriteLine(e);
                    Form test = new Form();
                    test.Text = "ERROR";
                    test.Size = new Size(300, 150);
                    Label message = new Label();
                    message.Text =
                        "Sorry, an error has occurred. please send the output and error logs to bomberdes@live.com, and i will fix it as soon as i can :)";
                    message.Parent = test;
                    message.Show();
                    message.Dock = DockStyle.Fill;
                    test.ShowDialog();
                }
                Console.WriteLine(e);
            }

            #endregion
        }
    }
#endif
}
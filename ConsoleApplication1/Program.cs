using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Readmain(Console.ReadLine());
        }

        private static void Readmain(string args)
        {
            string temp = args.Substring(0, 3);
            Console.WriteLine(temp);

            switch (temp)
            {
                case "PLA":
                    Console.WriteLine("Plain Tile");
                    PlainArgs(args);
                    break;
            }

        }

        private static void PlainArgs(string args)
        {
            string temp = args.Substring(args.Length - 3);
            Console.WriteLine(temp);
            switch (temp)
            {
                case "DIR":
                    Console.WriteLine("Dirt Tile");
                    break;
                case "GRA":
                    Console.WriteLine("Grass Tile");
                    break;
            }
            Main(null);
        }
    }
}

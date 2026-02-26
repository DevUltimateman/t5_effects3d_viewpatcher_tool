using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t5_effects3d_viewpatcher_tool
{
    internal class ConsoleWriter
    {

        public void WriteToConsoleMainTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("T5 Effects3d ViewPatcher Tool");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Copyright (C) 2026 by Ultimateman.\n");
        }

        public void WriteToConsoleChooseGameLocation( string chosen )
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Please select the Black Ops Root Folder.");
            while( chosen == null )
            {
                //Console.WriteLine("Waiting for user to select a folder...");
            }
            Console.Clear();
            WriteToConsoleMainTitle();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Black Ops folder selected successfully.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Location: " + chosen.ToString());

        }
    }
}

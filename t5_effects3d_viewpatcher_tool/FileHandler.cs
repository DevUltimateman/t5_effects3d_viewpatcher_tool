using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;

namespace t5_effects3d_viewpatcher_tool
{
    internal class FileHandler
    {
        public bool CheckIfStatusChecked = false;

        //dont seem to do none since console already reads and opens files that are dropped into it, but this is here just in case i want to add some sort of file reading functionality in the future.
        public string ReadFile( string filePath )
        {
            try
            {
                string fileContent = File.ReadAllText( filePath );
                Console.WriteLine("File read successfully: " + fileContent);
                return fileContent;
            }
            catch ( Exception ex )
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return string.Empty;
            }
        }


        public void AskForOverride()
        {
            string? yesNoInput = Console.ReadLine();
            bool checkState = false;
            //do clear
            if (yesNoInput != "N" || yesNoInput != "n")
            {
                checkState = true;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Clearing the previous dropdown list...");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Dropdown list cleared successfully.");
            }


            //dont clear
            if (yesNoInput == "N" || yesNoInput == "n")
            {
                checkState = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dropdown list left as is.\nDropdown list will be overwritten once more files are added.");
            }


            Console.Clear();
            CheckIfStatusChecked = true;
            if (checkState == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Clearing the previous dropdown list...");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Dropdown list cleared successfully.\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("You can now drop the files you want to add to the dropdown list.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Max file size amount: 8 files.");
            }
            else if ( checkState == false )
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Dropdown list left as is.\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("You can now drop the files you want to add to the dropdown list.");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Max file size amount: 8 files.");
            }
        }

        public void WaitForFileDrop()
        {
            string? fileWeWant = Console.ReadLine();
            
        }
    }
}

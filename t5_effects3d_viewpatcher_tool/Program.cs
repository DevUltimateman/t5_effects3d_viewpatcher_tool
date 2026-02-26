using System;
using System.Diagnostics;
using t5_effects3d_viewpatcher_tool;


ConsoleWriter consoleWriter = new ConsoleWriter();
ProcessStartInfo infoStarter = new ProcessStartInfo();
//INTRO TEXT**/

string gameLocation = infoStarter.Verb = "open";
consoleWriter.WriteToConsoleMainTitle();



//consoleWriter.WriteToConsoleChooseGameLocation(string s);
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Do you want to clear the previous dropdown list? (Y/N)");

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("It is reccommended to clear the prvious list values to avoid confusion.");



//DECIDE IF USER WANTS TO CLEAR THE PREVIOUS DROPDOWN LIST
FileHandler fH = new FileHandler();
fH.AskForOverride();


int x = 0;
while( fH.CheckIfStatusChecked == false )
{
    if( x == 0 )
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        x++;
    }
    Console.WriteLine("waiting for user for anything debug");
}

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("WE GOT FILE");

Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine(fH.giveMeAppData().ToString());  

//wait
Console.ReadLine();

if( args != null )
{
    Console.WriteLine("Arguments length: " + args.Length );
}
for ( int i = 0; i < args.Length; i++ )
{
    Console.WriteLine("Arguments: ");/*+ i + ": " + args[i]);*/
}

Console.ForegroundColor = ConsoleColor.DarkYellow;




//fH.ReadFile( Console.ReadLine());




//WAIT FOR A FILE TO BE DROPPED**/
//string? clearListInput = Console.ReadLine();
//FileHandler fH = new FileHandler();

//string? path = Console.ReadLine();
//Console.WriteLine("The filename: " + path);



return 0;


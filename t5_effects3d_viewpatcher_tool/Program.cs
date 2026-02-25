using System;
using t5_effects3d_viewpatcher_tool;


//INTRO TEXT**/
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("T5 Effects3d ViewPatcher Tool");

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Copyright (C) 2026 by Ultimateman.\n");

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

Console.ReadLine();
for ( int i = 0; i < args.Length; i++ )
{
    Console.WriteLine("Arguments: ");/*+ i + ": " + args[i]);*/
}
Console.WriteLine("TEST" + args[args.Length]);
Console.ForegroundColor = ConsoleColor.DarkYellow;



//fH.ReadFile( Console.ReadLine());




//WAIT FOR A FILE TO BE DROPPED**/
//string? clearListInput = Console.ReadLine();
//FileHandler fH = new FileHandler();

//string? path = Console.ReadLine();
//Console.WriteLine("The filename: " + path);



return 0;


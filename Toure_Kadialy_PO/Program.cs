using Serilog;
using System;
using Toure_Kadialy_P0.UI;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            //Initialize serilog object 
            //to write logs errors all
            //across the program.
            Log.Logger = new LoggerConfiguration()
              .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();
            Console.WriteLine("Hello World!");
            MenuLogin menu = new MenuLogin();
            // starting program at the menu
            menu.Start();
        }
    }
}

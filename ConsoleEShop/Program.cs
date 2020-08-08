using System;
using ConsoleEShop.DAL;
using ConsoleEShop.PL;

namespace ConsoleEShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello customer!");
            var consoleUi = new ConsoleUi();
            consoleUi.Start();
        }
    }
}

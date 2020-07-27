using System;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello customer!");
            var database = new CollectionDataBase();
            var shopWork = new ShopWork(database);
            shopWork.Start();
        }
    }
}

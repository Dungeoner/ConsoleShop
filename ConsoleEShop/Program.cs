using System;

namespace ConsoleEShop
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello User!");
            var database = new CollectionDataBase();
            var sessionFactory = new SessionFactory();
            var session = sessionFactory.Selection(database);
        }
    }
}

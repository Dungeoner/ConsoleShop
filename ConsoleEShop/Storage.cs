using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Storage
    {
        private Storage() { }
        private static Storage _instance = null;
        public int UserCount { get; set; } = 5;
        public int ProductCount { get; set; } = 13;

        public static Storage GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new Storage();
            return _instance;
        }
        public List<Product> Products { get; set; } = new List<Product>()
        {
            new Product("Stratocaster", 20000, ProductCategory.ElectricGuitar, "Fender"),
            new Product("Explorer", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product("Flying V", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product("Les Paul", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product("Snakebite", 20000, ProductCategory.ElectricGuitar, "ESP"),
            new Product("Viper", 20000, ProductCategory.ElectricGuitar, "ESP"),
            new Product("Streamer", 20000, ProductCategory.Base, "Warwick"),
            new Product("Corvette", 20000, ProductCategory.Base, "Warwick"),
            new Product("4003", 20000, ProductCategory.Base, "Rickenbacker"),
            new Product("FG800", 20000, ProductCategory.AcousticGuitar, "Yamaha"),
            new Product("LS-TA", 20000, ProductCategory.AcousticGuitar, "Yamaha"),
            new Product("GPC-15", 20000, ProductCategory.AcousticGuitar, "Martin"),
            new Product("SLG-200", 20000, ProductCategory.AcousticGuitar, "Yamaha"),

        };

        public List<User> Users { get; set; } = new List<User>()
        {
            new Admin("admin", 1),
            new RegisteredUser("vasya2002", 2),
            new RegisteredUser("Alex_1", 3),
            new RegisteredUser("Dimas33", 4),
            new RegisteredUser("GPlayer", 5)
        };
        

        public List<Order> OrderHistory { get; set; }
    }
}

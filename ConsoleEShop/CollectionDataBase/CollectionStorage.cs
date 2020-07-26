using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Users;

namespace ConsoleEShop
{
    class CollectionStorage
    {
        private CollectionStorage() { }
        private static CollectionStorage _instance = null;
        public int UserCount { get; set; } = 5;
        public int ProductCount { get; set; } = 13;

        public static CollectionStorage GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new CollectionStorage();
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
            new User("admin", UserType.Admin, 1),
            new User("vasya2002", UserType.User, 2),
            new User("Alex_1", UserType.User, 3),
            new User("Dimas33", UserType.User, 4),
            new User("GPlayer", UserType.User, 5)
        };
        

        public List<Order> OrderHistory { get; set; }
    }
}

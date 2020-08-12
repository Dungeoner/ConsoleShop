using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL
{   
    /// <summary>
    /// This class used for storage data in collections instead of database
    /// </summary>
    public class CollectionDataBase : IDataBase
    {
        /// <summary>
        /// List of products
        /// </summary>
        public List<Product> Products { get;} = new List<Product>
        {
            new Product(1,"Stratocaster", 20000, ProductCategory.ElectricGuitar, "Fender"),
            new Product(2,"Explorer", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product(3,"Flying V", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product(4,"Les Paul", 20000, ProductCategory.ElectricGuitar, "Gibson"),
            new Product(5,"Snakebite", 20000, ProductCategory.ElectricGuitar, "ESP"),
            new Product(6,"Viper", 20000, ProductCategory.ElectricGuitar, "ESP"),
            new Product(7,"Streamer", 20000, ProductCategory.Base, "Warwick"),
            new Product(8,"Corvette", 20000, ProductCategory.Base, "Warwick"),
            new Product(9,"4003", 20000, ProductCategory.Base, "Rickenbacker"),
            new Product(10,"FG800", 20000, ProductCategory.AcousticGuitar, "Yamaha"),
            new Product(11,"LS-TA", 20000, ProductCategory.AcousticGuitar, "Yamaha"),
            new Product(12,"GPC-15", 20000, ProductCategory.AcousticGuitar, "Martin"),
            new Product(13,"SLG-200", 20000, ProductCategory.AcousticGuitar, "Yamaha")

        };

        /// <summary>
        /// List of users
        /// </summary>
        public List<User> Users { get;} = new List<User>
        {
            new User("admin", UserType.Admin, 1),
            new User("vasya2002", UserType.User, 2),
            new User("Alex_1", UserType.User, 3),
            new User("Dimas33", UserType.User, 4),
            new User("GPlayer", UserType.User, 5)
        };
        /// <summary>
        /// List of orders
        /// </summary>
        public List<Order> OrderHistory { get;} = new List<Order>();
    }
}

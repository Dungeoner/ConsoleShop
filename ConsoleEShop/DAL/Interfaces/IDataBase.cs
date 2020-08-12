using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.DAL.Entities;

namespace ConsoleEShop.DAL.Interfaces
{
    public interface IDataBase
    {
        /// <summary>
        /// List of products
        /// </summary>
        List<Product> Products { get;}
        /// <summary>
        /// List of users
        /// </summary>
        List<User> Users { get;}
        /// <summary>
        /// List of orders
        /// </summary>
        List<Order> OrderHistory { get;}
    }
}

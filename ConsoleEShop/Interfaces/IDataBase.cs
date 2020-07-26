using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    interface IDataBase
    {
        List<User> GetUserList();
        List<Product> GetProductList();
        List<Order> GetOrderList();
        void AddProduct(Product product);
        void AddUser(string userName);
        void AddOrder(Order order);
        bool RemoveUser(string userName);
        bool RemoveProduct(string productName);
        User FindUser(string userName);
        Product FindProduct(string productName);

    }
}

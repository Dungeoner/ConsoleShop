using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    public interface IDataBase
    {
        List<User> GetUserList();
        List<Product> GetProductList();
        List<Order> GetOrderList();
        void AddProduct(string productName, int price, ProductCategory category, string description);
        void AddUser(string userName);
        void AddOrder(Product product, int userId);
        User FindUser(string userName);
        Product FindProduct(string productName);

    }
}

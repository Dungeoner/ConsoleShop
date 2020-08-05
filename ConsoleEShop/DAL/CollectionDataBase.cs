using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    public class CollectionDataBase : IDataBase
    {
        private readonly CollectionStorage _cdb;

        public CollectionDataBase()
        {
            _cdb = new CollectionStorage();
        }

        public List<User> GetUserList()
        {
            return _cdb.Users;
        }

        public List<Product> GetProductList()
        {
            return _cdb.Products;
        }

        public List<Order> GetOrderList()
        {
            return _cdb.OrderHistory;
        }

        public void AddProduct(string productName, int price, ProductCategory category, string description)
        {
            _cdb.Products.Add(new Product(_cdb.ProductCount++, productName, price, category, description));
        }

        public void AddUser(string userName)
        {
            _cdb.Users.Add(new User(userName, UserType.User, _cdb.UserCount++));
        }

        public void AddOrder(Product product, int userId)
        {
            _cdb.OrderHistory.Add(new Order(product, userId, _cdb.OrderCount++ ));
        }

        public User FindUser(string userName)
        {
            return _cdb.Users.Find(x => x.UserName == userName);
        }

        public Product FindProduct(string productName)
        {
            return _cdb.Products.Find(x => x.ProductName == productName);
        }

    }
}

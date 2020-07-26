using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleEShop.Users;

namespace ConsoleEShop
{
    class CollectionDataBase : IDataBase
    {
        
        public List<User> GetUserList()
        {
            return CollectionStorage.GetInstance().Users;
        }

        public List<Product> GetProductList()
        {
            return CollectionStorage.GetInstance().Products;
        }

        public List<Order> GetOrderList()
        {
            return CollectionStorage.GetInstance().OrderHistory;
        }

        public void AddProduct(Product product)
        {
            CollectionStorage.GetInstance().Products.Add(product);
        }

        public void AddUser(string userName)
        {
            CollectionStorage.GetInstance().Users.Add(new User(userName, UserType.User, CollectionStorage.GetInstance().UserCount++));
        }

        public void AddOrder(Order order)
        {
            CollectionStorage.GetInstance().OrderHistory.Add(order);
        }

        public bool RemoveUser(string userName)
        {
            var user = FindUser(userName);
            return user != null && CollectionStorage.GetInstance().Users.Remove(user);

        }
        public bool RemoveProduct(string productName)
        {
            var product = FindProduct(productName);
            return product != null && CollectionStorage.GetInstance().Products.Remove(product);
        }

        public User FindUser(string userName)
        {
            return CollectionStorage.GetInstance().Users.Find(x => x.UserName == userName);
        }

        public Product FindProduct(string productName)
        {
            return CollectionStorage.GetInstance().Products.Find(x => x.ProductName == productName);
        }

        
    }
}

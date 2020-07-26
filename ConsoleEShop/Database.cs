using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleEShop
{
    class Database : IDataBase
    {
        
        public List<User> GetUserList()
        {
            return Storage.GetInstance().Users;
        }

        public List<Product> GetProductList()
        {
            return Storage.GetInstance().Products;
        }

        public List<Order> GetOrderList()
        {
            return Storage.GetInstance().OrderHistory;
        }

        public void AddProduct(Product product)
        {
            Storage.GetInstance().Products.Add(product);
        }

        public void AddUser(string userName)
        {
            Storage.GetInstance().Users.Add(new RegisteredUser(userName, Storage.GetInstance().UserCount++));
        }

        public void AddOrder(Order order)
        {
            Storage.GetInstance().OrderHistory.Add(order);
        }

        public bool RemoveUser(string userName)
        {
            var user = FindUser(userName);
            return user != null && Storage.GetInstance().Users.Remove(user);

        }
        public bool RemoveProduct(string productName)
        {
            var product = FindProduct(productName);
            return product != null && Storage.GetInstance().Products.Remove(product);
        }

        public User FindUser(string userName)
        {
            return Storage.GetInstance().Users.Find(x => x.UserName == userName);
        }

        public Product FindProduct(string productName)
        {
            return Storage.GetInstance().Products.Find(x => x.ProductName == productName);
        }

        
    }
}

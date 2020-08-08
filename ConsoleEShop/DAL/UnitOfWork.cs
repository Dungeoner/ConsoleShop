using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;
using ConsoleEShop.DAL.Repositories;

namespace ConsoleEShop.DAL
{
    public class CollectionUnitOfWork
    {
        private readonly CollectionDataBase _cdb;
        private IRepository<Order> _orders;
        private IRepository<Product> _products;
        private IRepository<User> _users;
        public IRepository<Order> Orders => _orders ?? new OrderRepository(_cdb);

        public IRepository<Product> Products => _products ?? new ProductRepository(_cdb);
        public IRepository<User> Users => _users ?? new UserRepository(_cdb);

        public CollectionUnitOfWork()
        {
            _cdb = new CollectionDataBase();
        }
    }
}

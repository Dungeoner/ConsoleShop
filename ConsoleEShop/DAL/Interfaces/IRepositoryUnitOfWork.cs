using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Repositories;

namespace ConsoleEShop.DAL.Interfaces
{
    public interface IRepositoryUnitOfWork
    {
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
        IRepository<User> Users { get; }
    }
}

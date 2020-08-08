using System;
using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly CollectionDataBase _context;

        public OrderRepository(CollectionDataBase context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetItemList()
        {
            return _context.OrderHistory;
        }

        public Order GetItem(string itemName)
        {
            return _context.OrderHistory.Find(x => x.OrderId == Convert.ToInt32(itemName));
        }

        public void AddItem(Order item)
        {
            _context.OrderHistory.Add(item);
        }

        public void DeleteItem(Order item)
        {
            _context.OrderHistory.Remove(item);
        }
    }
}

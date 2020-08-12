using System;
using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    /// <summary>
    /// Class used to work with orders in Collection database
    /// </summary>
    public class OrderRepository : IRepository<Order>
    {
        private readonly IDataBase _context;
        /// <param name="context"> Current database </param>
        public OrderRepository(IDataBase context)
        {
            _context = context;
            ItemCount = _context.OrderHistory.Count;
        }

        public int ItemCount { get; set; }

        /// <summary>
        /// Method for get all orders from database
        /// </summary>
        /// <returns>IEnumerable of orders</returns>
        public IEnumerable<Order> GetItemList()
        {
            return _context.OrderHistory;
        }
        /// <summary>
        /// Get order from database by id
        /// </summary>
        /// <param name="itemName"> Order id </param>
        /// <returns> Order </returns>
        public Order GetItem(string itemName)
        {
            return _context.OrderHistory.Find(x => x.OrderId == Convert.ToInt32(itemName));
        }
        /// <summary>
        /// Add new order to database
        /// </summary>
        /// <param name="item">New order </param>
        public void AddItem(Order item)
        {
            _context.OrderHistory.Add(item);
        }
    }
}

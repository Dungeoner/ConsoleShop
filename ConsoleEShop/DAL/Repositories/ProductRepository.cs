using System;
using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    /// <summary>
    /// Class used to work with products in Collection database
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {
        private readonly IDataBase _context;
        /// <param name="context"> Current database </param>
        public ProductRepository(IDataBase context)
        {
            _context = context;
            ItemCount = _context.Products.Count;
        }

        public int ItemCount { get; set; }

        /// <summary>
        /// Method for get all products from database
        /// </summary>
        /// <returns>IEnumerable of products</returns>
        public IEnumerable<Product> GetItemList()
        {
            return _context.Products;
        }
        /// <summary>
        /// Get order from database by productName
        /// </summary>
        /// <param name="itemName"> Product id </param>
        /// <returns> Product </returns>
        public Product GetItem(string itemName)
        {
            return _context.Products.Find(x => x.Id == Convert.ToInt32(itemName));
        }
        /// <summary>
        /// Add new product to database
        /// </summary>
        /// <param name="item">New product </param>
        public void AddItem(Product item)
        {
            _context.Products.Add(item);
        }
    }
}

using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly CollectionDataBase _context;

        public ProductRepository(CollectionDataBase context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetItemList()
        {
            return _context.Products;
        }

        public Product GetItem(string itemName)
        {
            return _context.Products.Find(x => x.ProductName == itemName);
        }

        public void AddItem(Product item)
        {
            _context.Products.Add(item);
        }

        public void DeleteItem(Product item)
        {
            _context.Products.Remove(item);
        }
    }
}

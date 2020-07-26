using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleEShop
{
    class ProductManager
    {
        public ProductManager(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        private readonly IDataBase _dataBase;

        public void ProductView()
        {
            var i = 1;
            foreach (var product in _dataBase.GetProductList())
            {
                Console.WriteLine($"{i}, {product}");
                i++;
            }
        }

        public void AddProduct(Product product)
        {
            _dataBase.AddProduct(product);
        }

        public List<Product> Search(string productName)
        {
            return (List<Product>) _dataBase.GetProductList().Where(x => x.ProductName.Contains(productName));
        }


}
}

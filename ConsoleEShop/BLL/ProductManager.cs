using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleEShop.Enums;

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
                Console.WriteLine($"{i}. {product}");
                i++;
            }
        }

        public void AddProduct()
        {
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine() ?? throw new ArgumentNullException();
            Console.WriteLine("Enter price:");
            int price = Convert.ToInt32(Console.ReadLine() ?? throw new ArgumentNullException());
            Console.WriteLine("Choose category: \n\t 1 AcousticGuitar \n\t 2 Base \n\t ElectricGuitar");
            ProductCategory category;
            switch (Console.ReadLine() ?? throw new ArgumentNullException())
            {
                case "1":
                    category = ProductCategory.AcousticGuitar;
                    break;
                case "2":
                    category = ProductCategory.Base;
                    break;
                case "3":
                    category = ProductCategory.ElectricGuitar;
                    break;
                default: throw new ArgumentException("Wrong number");
            }
            Console.WriteLine("Enter description:");
            var description = Console.ReadLine() ?? throw new ArgumentNullException();
            _dataBase.AddProduct(productName, price, category, description);
        }

        public void ChangeProductData()
        {
            Console.WriteLine("Enter product name:");
            var product = _dataBase.FindProduct(Console.ReadLine());
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine() ?? throw new ArgumentNullException();
            Console.WriteLine("Enter price:");
            int price = Convert.ToInt32(Console.ReadLine() ?? throw new ArgumentNullException());
            Console.WriteLine("Choose category: \n\t 1 AcousticGuitar \n\t 2 Base \n\t 3 ElectricGuitar");
            ProductCategory category;
            switch (Console.ReadLine() ?? throw new ArgumentNullException())
            {
                case "1":
                    category = ProductCategory.AcousticGuitar;
                    break;
                case "2":
                    category = ProductCategory.Base;
                    break;
                case "3":
                    category = ProductCategory.ElectricGuitar;
                    break;
                default: throw new ArgumentException("Wrong number");
            }
            Console.WriteLine("Enter description:");
            var description = Console.ReadLine() ?? throw new ArgumentNullException();
            product.ProductName = productName;
            product.Category = category;
            product.Description = description;
            product.Price = price;

        }


        public void Search()
        {
            Console.WriteLine("Enter product name");
            var pn = Console.ReadLine() ?? throw new InvalidOperationException();
            var result = _dataBase.GetProductList().Where(x =>
                x.ProductName.Contains(pn));
            foreach (var product in result)
            {    
                Console.WriteLine(product);
            }

        }


}
}

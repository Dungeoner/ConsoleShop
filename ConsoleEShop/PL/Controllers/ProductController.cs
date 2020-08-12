using System;
using System.Collections.Generic;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.PL.Management
{
    public class ProductController
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }
        public void ProductView()
        {
            var result = _service.ProductView();
            var i = 1;
            foreach (var product in result)
            {
                Console.WriteLine($"{i++}. {product.ProductName} {product.Price} {product.Category} {product.Description}");
            }
        }

        public void AddProduct()
        {
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine() ?? throw new UserInputException("Can't be empty");
            Console.WriteLine("Enter price:");
            var price = Convert.ToInt32(Console.ReadLine() ?? throw new UserInputException("Can't be empty"));
            Console.WriteLine("Choose category: \n\t 1 AcousticGuitar \n\t 2 Base \n\t ElectricGuitar");
            ProductCategory category;
            switch (Console.ReadLine() ?? throw new UserInputException("Can't be empty"))
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
                default: throw new UserInputException("Wrong number");
            }
            Console.WriteLine("Enter description:");
            var description = Console.ReadLine() ?? string.Empty;
            _service.AddProduct(productName, price, category, description);
        }

        public void ChangeProductData()
        {
            Console.WriteLine("Enter product id:");
            var product = _service.GetProductById(Console.ReadLine());
            Console.WriteLine("Enter new product name:");
            var productName = Console.ReadLine() ?? throw new UserInputException("Can't be empty");
            Console.WriteLine("Enter new price:");
            var price = Convert.ToInt32(Console.ReadLine() ?? throw new UserInputException("Can't be empty"));
            Console.WriteLine("Choose new category: \n\t 1 AcousticGuitar \n\t 2 Base \n\t 3 ElectricGuitar");
            ProductCategory category;
            switch (Console.ReadLine() ?? throw new UserInputException("Can't be empty"))
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
                default: throw new UserInputException("Wrong number");
            }
            Console.WriteLine("Enter new description:");
            var description = Console.ReadLine();
            product.ProductName = productName;
            product.Category = category;
            product.Description = description;
            product.Price = price;
        }


        public void Search()
        {
            var searchResult = _service.Search(Console.ReadLine() ?? throw new UserInputException("Please, enter something"));
            var i = 1;
            foreach (var product in searchResult)
            {
                Console.WriteLine($"{i++}. {product.ProductName} {product.Price} {product.Category} {product.Description}");
            }
        }
    }
}

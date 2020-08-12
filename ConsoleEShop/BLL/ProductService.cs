using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{
    public class ProductService
    {
        public ProductService(IRepositoryUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Products;
        }

        private readonly IRepository<Product> _repository;


        public IEnumerable<Product> ProductView()
        {
            return _repository.GetItemList();
        }

        public void AddProduct(string productName, int price, ProductCategory category, string description) =>
            _repository.AddItem(new Product(_repository.GetItemList().Count(), productName, price, category, description));

        public void ChangeProductData()
        {
            Console.WriteLine("Enter product name:");
            var product = _repository.GetItem(Console.ReadLine() ?? throw new UserInputException("Product not found"));
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

        public Product GetProductById(string id) => _repository.GetItem(id) ?? throw new UserInputException("Product not found");


        public IEnumerable<Product> Search(string productName)
        {
            return _repository.GetItemList().Where(x =>
                x.ProductName.Contains(productName));
        }


    }
}

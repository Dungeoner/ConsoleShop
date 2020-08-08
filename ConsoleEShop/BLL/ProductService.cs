using System;
using System.Linq;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{
    public class ProductService : Iservice
    {
        public ProductService(CollectionUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Products;
        }

        private readonly IRepository<Product> _repository;

       
        public void ProductView()
        {
            var i = 1;
            foreach (var product in _repository.GetItemList())
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
            var price = Convert.ToInt32(Console.ReadLine() ?? throw new ArgumentNullException());
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
            _repository.AddItem(new Product(_repository.GetItemList().Count(), productName, price, category, description));
        }

        public void ChangeProductData()
        {
            Console.WriteLine("Enter product name:");
            var product = _repository.GetItem(Console.ReadLine());
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine() ?? throw new ArgumentNullException();
            Console.WriteLine("Enter price:");
            var price = Convert.ToInt32(Console.ReadLine() ?? throw new ArgumentNullException());
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
            var result = _repository.GetItemList().Where(x =>
                x.ProductName.Contains(pn));
            foreach (var product in result)
            {    
                Console.WriteLine(product);
            }

        }


}
}

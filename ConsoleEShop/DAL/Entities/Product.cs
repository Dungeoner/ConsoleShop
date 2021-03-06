﻿using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.DAL.Entities
{
    public class Product
    {
        public Product(int id, string productName, int price, ProductCategory category, string description)
        {
            Id = id;
            Category = category;
            Price = price;
            Description = description;
            ProductName = productName;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }

    }

}

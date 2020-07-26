using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEShop
{
    class Product
    {
        public Product(string productName, int price, ProductCategory category, string description)
        {
            Category = category;
            Price = price;
            Description = description;
            ProductName = productName;
        }

        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }

        public override string ToString()
        {
            return $"{ProductName}, {Price}, {Category}, {Description}";
        }
    }

}

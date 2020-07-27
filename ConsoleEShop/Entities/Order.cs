using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
     public class Order
    {
        public Order(Product product, int userId)
        {
            Product = product;
            UserId = userId;
            Status = OrderStatus.New;
        }

        public OrderStatus Status { get; set; }
        public Product Product { get;}

        public int UserId { get;}
    }

    
}

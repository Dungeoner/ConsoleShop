﻿using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.DAL.Entities
{
     public class Order
    {
        public Order(Product product, int userId, int orderId)
        {
            Product = product;
            UserId = userId;
            OrderId = orderId;
            Status = OrderStatus.New;
        }

        public OrderStatus Status { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }

        public int UserId { get;}
        public override string ToString()
        {
            return $"{OrderId} {Product} {UserId} {Status}";
        }
    }

    
}
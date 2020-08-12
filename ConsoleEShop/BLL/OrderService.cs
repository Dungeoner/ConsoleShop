using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{
    public class OrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepositoryUnitOfWork unitOfWork)
        {
            _orderRepository = unitOfWork.Orders;
            _productRepository = unitOfWork.Products;
        }

        public void Create(Product product, User user) =>_orderRepository.AddItem(new Order(product, user, _orderRepository.ItemCount++));
        

        public IEnumerable<Order> OrderHistory(User user) => user.Type == UserType.Admin ? _orderRepository.GetItemList() : _orderRepository.GetItemList().Where(x => x.User == user);


        public void ChangeStatus(string id, OrderStatus status)
        {
            _orderRepository.GetItem(id).Status = status;
        }

    }
}

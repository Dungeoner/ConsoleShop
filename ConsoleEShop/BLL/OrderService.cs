using System;
using System.Linq;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{
    public class OrderService : Iservice
    {
        public OrderService(CollectionUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Orders;
        }

        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> _productRepository;

        public void Create(User user)
        {
            Console.WriteLine("Enter product name:");
            var product = _productRepository.GetItem(Console.ReadLine());
            var b = false;
            do
            {
                Console.WriteLine($"Is it right? \n {product} \n Write \"Yes\" or \"No\" any key fo r cancel");
                var res = Console.ReadLine() ?? throw new ArgumentException("Wrong answer!");
                switch (res.ToLower())
                {
                    case "yes":
                        _repository.AddItem(new Order(product, user.Id, _repository.GetItemList().Count()));
                        break;
                    case "no":
                        b = true;
                        break;
                    default: return;
                } 
                
            } while (b);
        }

        public void OrderHistory(User user)
        {
            var result = _repository.GetItemList().Where(x => x.UserId == user.Id);
            var i = 1;
            foreach (var order in result)
            {
                Console.WriteLine($"{i}. {order}");
                i++;
            }
        }
        

        public void ChangeStatus(User user)
        {
            Console.WriteLine("Enter order id:");
            var order = _repository.GetItemList().First(x => x.OrderId == Convert.ToInt32(Console.ReadLine()));
            if (user.Type == UserType.User)
            {
                var b = false;
                do
                {
                    Console.WriteLine($"Is it right? \n {order} \n Write \"Yes\" or \"No\" any key fo r cancel");
                    var res = Console.ReadLine() ?? default;
                    switch (res.ToLower())
                    {
                        case "yes":
                            order.Status = OrderStatus.CanceledByUser;
                            break;
                        case "no":
                            b = true;
                            break;
                        default: return;
                    }

                } while (b);
            }
            else
            {
                Console.WriteLine("Choose status : \n\t 1 CanceledByAdmin \n\t 2 PaymentReceived \n\t 3 Received \n\t 4 Finished \n\t any key fo cancel");
                OrderStatus orderStatus;
                switch (Console.ReadLine())
                {
                    case "1":
                        orderStatus = OrderStatus.CanceledByAdmin;
                        break;
                    case "2":
                        orderStatus = OrderStatus.PaymentReceived;
                        break;
                    case "3":
                        orderStatus = OrderStatus.Received;
                        break;
                    case "4":
                        orderStatus = OrderStatus.Finished;
                        break;
                    default: return;
                }
                var b = false;
                do
                {
                    Console.WriteLine($"Is it right? \n {order} \n Write \"Yes\" or \"No\" any key fo r cancel");
                    var res = Console.ReadLine() ?? default;
                    switch (res.ToLower())
                    {
                        case "yes":
                            order.Status = orderStatus;
                            break;
                        case "no":
                            b = true;
                            break;
                        default: return;
                    }

                } while (b);
            }
        }

    }
}

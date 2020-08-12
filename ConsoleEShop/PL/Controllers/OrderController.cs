using System;
using System.Linq;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.PL.Management
{
    public class OrderController
    {
        private readonly OrderService _orderService;
        private readonly ProductService _productService;

        public OrderController(OrderService orderService, ProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public void Create(User user)
        {
            Console.WriteLine("Enter product name:");
            var productName = Console.ReadLine();
            if (productName == string.Empty) throw new UserInputException("Name can't be empty");
            var searchResult =  _productService.Search(productName) ?? throw new UserInputException("Product not found");
            var i = 1;
            foreach (var product in searchResult)
            {
                Console.WriteLine($"{i++} {product.ProductName} {product.Price} {product.Category} {product.Description}");
            }
            Console.WriteLine("Enter number of product:");
            var productNumber = Convert.ToInt32(Console.ReadLine() ?? throw new UserInputException("You've entered nothing"));
            if(productNumber > searchResult.Count()) throw new UserInputException("Number is out of range");
            _orderService.Create(searchResult.ElementAt(productNumber - 1), user);

        }

        public void OrderHistory(User user)
        {
            var result = _orderService.OrderHistory(user);
            var i = 1;
            foreach (var order in result)
            {
                Console.WriteLine($"{i++}. {order.Product.ProductName} {order.Product.Price} Status: {order.Status} Customer: {order.User.UserName}");
            }
        }


        public void ChangeStatus(User user)
        {
            Console.WriteLine("Enter order id:");
            var id = (Console.ReadLine());
            if (id == string.Empty) throw new UserInputException("Id can't be empty");
            if (user.Type == UserType.User)
            {
                var b = false;
                do
                {
                    var order = _orderService.OrderHistory(user).First(x => x.OrderId.ToString() == id) ?? throw new UserInputException("Wrong order id");
                    Console.WriteLine($"Is it right? \n {order} \n Write \"Yes\" or \"No\" any key for cancel");
                    var res = Console.ReadLine();
                    switch (res?.ToLower())
                    {
                        case "yes":
                            _orderService.ChangeStatus(id, OrderStatus.CanceledByUser);
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
                var order = _orderService.OrderHistory(user).First(x => x.OrderId.ToString() == id) ?? throw new UserInputException("Wrong order id");
                Console.WriteLine("Choose status : \n\t 1 CanceledByAdmin \n\t 2 PaymentReceived \n\t 3 Received \n\t 4 Finished \n\t any key for cancel");
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
                    switch (Console.ReadLine()?.ToLower())
                    {
                        case "yes":
                            _orderService.ChangeStatus(id, orderStatus);
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

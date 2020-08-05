using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    class OrderManager
    {
        public OrderManager(IDataBase database)
        {
            _dataBase = database;
        }

        private readonly IDataBase _dataBase;

        public void Create(User user)
        {
            Console.WriteLine("Enter product name:");
            var product = _dataBase.FindProduct(Console.ReadLine());
            var b = false;
            do
            {
                Console.WriteLine($"Is it right? \n {product} \n Write \"Yes\" or \"No\" any key fo r cancel");
                var res = Console.ReadLine() ?? throw new ArgumentException("Wrong answer!");
                switch (res.ToLower())
                {
                    case "yes":
                        _dataBase.AddOrder(product, user.Id);
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
            var result = _dataBase.GetOrderList().FindAll(x => x.UserId == user.Id);
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
            var order = _dataBase.GetOrderList().Find(x => x.OrderId == Convert.ToInt32(Console.ReadLine()));
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
                            _dataBase.GetOrderList().Find(x => x == order).Status = OrderStatus.CanceledByUser;
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
                            _dataBase.GetOrderList().Find(x => x == order).Status = orderStatus;
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

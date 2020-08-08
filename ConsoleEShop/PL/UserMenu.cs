using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL.Entities;

namespace ConsoleEShop.PL
{
    class UserMenu
    {
        private Menu _menu;
        private readonly ServiceUnitOfWork _services;
        private readonly User _user;
        public UserMenu(Menu menu, ServiceUnitOfWork services, User user)
        {
            _menu = menu;
            _services = services;
            _user = user;
        }
        public void Run()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for create new order \n\t 4 for view your order history"
            +
            " \n\t 5  for cancel processed order \n\t 6 for change your personal data \n\t 7 for logout  \n\t any key for exit");

            switch (Console.ReadLine())
            {
                case "1":
                    _services.ProductService.ProductView();
                    _menu.Invoke(1);
                    break;
                case "2":
                    _services.ProductService.Search();
                    _menu.Invoke(1);
                    break;
                case "3":
                    _services.OrderService.Create(_user);
                    _menu.Invoke(1);
                    break;
                case "4":
                    _services.OrderService.OrderHistory(_user);
                    _menu.Invoke(1);
                    break;
                case "5":
                    _services.OrderService.ChangeStatus(_user);
                    _menu.Invoke(1);
                    break;
                case "6":
                    _services.AccountService.ChangeData(_user);
                    _menu.Invoke(1);
                    break;
                case "7":
                    _menu.Invoke();
                break;
                default: break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL.Entities;

namespace ConsoleEShop.PL
{
    class AdminMenu
    {
        private Menu _menu;
        private readonly ServiceUnitOfWork _services;
        private readonly User _user;

        public AdminMenu(Menu menu, ServiceUnitOfWork services, User user)
        {
            _menu = menu;
            _services = services;
            _user = user;
        }

        public void Run()
        {
            Console.WriteLine(
                "Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for create new order \n\t 4 for order history" +
                " \n\t 5 for change order status \n\t 6 for view user data \n\t 7 for change user data \n\t 8 for add new product \n\t 9 for change product info" +
                " \n\t 10 for logout  \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    _services.ProductService.ProductView();
                    _menu.Invoke(2);
                    break;
                case "2":
                    _services.ProductService.Search();
                    _menu.Invoke(2);
                    break;
                case "3":
                    _services.OrderService.Create(_user);
                    _menu.Invoke(2);
                    break;
                case "4":
                    _services.OrderService.OrderHistory(_user);
                    _menu.Invoke(2);
                    break;
                case "5":
                    _services.OrderService.ChangeStatus(_user);
                    _menu.Invoke(2);
                    break;
                case "6":
                    _services.AccountService.ViewUserData();
                    _menu.Invoke(2);
                    break;
                case "7":
                    _services.AccountService.ChangeData(_user);
                    _menu.Invoke(2);
                    break;
                case "8":
                    _services.ProductService.AddProduct();
                    _menu.Invoke(2);
                    break;
                case "9":
                    _services.ProductService.ChangeProductData();
                    _menu.Invoke();
                    break;
                case "10":
                    _menu.Invoke();
                    break;
                default: break;
            }
        }
    }
}

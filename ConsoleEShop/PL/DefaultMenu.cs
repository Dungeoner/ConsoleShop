using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.PL
{
    class DefaultMenu
    {
        private Menu _menu;
        private readonly ServiceUnitOfWork _services;
        private User _user;
        public DefaultMenu(Menu menu, ServiceUnitOfWork services)
        {
            _menu = menu;
            _services = services;
        }
        public void Run()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for login \n\t 4 for register \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    _services.ProductService.ProductView();
                    _menu.Invoke();
                    break;
                case "2":
                    _services.ProductService.Search();
                    _menu.Invoke();
                    break;
                case "3":
                    _user = _services.AccountService.Login();

                    switch (_user.Type)
                    {
                        case UserType.User:
                            _menu(1);
                            break;
                        case UserType.Admin:
                            _menu(2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    _menu?.Invoke();
                    break;
                case "4":
                    _user = _services.AccountService.Register();
                    switch (_user.Type)
                    {
                        case UserType.User:
                            _menu(1);
                            break;
                        case UserType.Admin:
                            _menu(2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    _menu?.Invoke();
                    break;
                default: break;
            }
        }
    }
}

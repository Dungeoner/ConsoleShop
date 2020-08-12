using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.PL.Controllers;
using ConsoleEShop.PL.Management;

namespace ConsoleEShop.PL
{
    class DefaultMenu
    {
        private readonly Menu _menu;
        private readonly ControllerUOF _manager;
        private User _user;
        public DefaultMenu(Menu menu, ControllerUOF services)
        {
            _menu = menu;
            _manager = services;
        }
        public void Run()
        {
            Console.WriteLine("Press: \n\t 1 for View products \n\t 2 for search \n\t 3 for login \n\t 4 for register \n\t any key for exit");
            switch (Console.ReadLine())
            {
                case "1":
                    _manager.ProductManager.ProductView();
                    _menu.Invoke();
                    break;
                case "2":
                    _manager.ProductManager.Search();
                    _menu.Invoke();
                    break;
                case "3":
                    try
                    {
                        _user = _manager.AccountManager.Login();
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                        _menu?.Invoke();
                        break;
                    }
                    _menu?.Invoke(_user);
                    break;
                case "4":
                    try
                    {
                        _user = _manager.AccountManager.Register();
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                        _menu?.Invoke();
                        break;
                    }
                    _menu?.Invoke(_user);
                    break;
                default: break;
            }
        }
    }
}

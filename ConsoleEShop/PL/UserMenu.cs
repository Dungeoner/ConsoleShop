using System;
using System.Collections.Generic;
using System.Text;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.PL.Controllers;
using ConsoleEShop.PL.Management;

namespace ConsoleEShop.PL
{
    class UserMenu
    {
        private readonly Menu _menu;
        private readonly ControllerUOF _manager;
        private readonly User _user;
        public UserMenu(Menu menu, ControllerUOF manager, User user)
        {
            _menu = menu;
            _manager = manager;
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
                    _manager.ProductManager.ProductView();
                    _menu.Invoke(_user);
                    break;
                case "2":
                    try
                    {
                        _manager.ProductManager.Search();
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    _menu.Invoke(_user);
                    break;
                case "3":
                    try
                    {
                        _manager.OrderManager.Create(_user);
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    _menu.Invoke(_user);
                    break;
                case "4":
                    _manager.OrderManager.OrderHistory(_user);
                    _menu.Invoke(_user);
                    break;
                case "5":
                    try
                    {
                        _manager.OrderManager.ChangeStatus(_user);
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    _menu.Invoke(_user);
                    break;
                case "6":
                    try
                    {
                       _manager.AccountManager.ChangeData(_user);
                    }
                    catch (UserInputException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    _menu.Invoke(_user);
                    break;
                case "7":
                    _menu.Invoke();
                break;
                default: break;
            }
        }
    }
}

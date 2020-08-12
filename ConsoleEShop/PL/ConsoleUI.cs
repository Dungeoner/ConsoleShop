using System;
using System.Threading;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.PL.Controllers;
using ConsoleEShop.PL.Management;

namespace ConsoleEShop.PL

{
    public delegate void Menu(User user = null);

    public class ConsoleUi
    {
        private readonly ControllerUOF _services;
        private readonly Menu _menu;
        
        public ConsoleUi()
        {
            _services = new ControllerUOF(new CollectionDataBase());
            _menu = Menu;
        }

        public void Start()
        {
            _menu.Invoke();
        }

        private void Menu(User user = null)
        {
            switch (user?.Type)
            {
                case UserType.User:
                    var userMenu = new UserMenu(_menu, _services, user);
                    userMenu.Run();
                    break;
                case UserType.Admin:
                    var adminMenu = new AdminMenu(_menu, _services, user);
                    adminMenu.Run();
                    break;
                default:
                    var defaultMenu = new DefaultMenu(_menu, _services);
                    defaultMenu.Run();
                    break;
            }
        }
    }
}

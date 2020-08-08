using System;
using System.Threading;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.PL

{
    public delegate void Menu(int i = 0);

    public class ConsoleUi
    {
        private readonly ServiceUnitOfWork _services;
        private readonly Menu _menu;
        private readonly User _user;

        public ConsoleUi()
        {
            _services = new ServiceUnitOfWork();
            _user = null;
            _menu = Menu;
        }

        public void Start()
        {
            _menu.Invoke();
        }

        private void Menu(int i = 0)
        {
            switch (i)
            {
                case 1:
                    var userMenu = new UserMenu(_menu, _services, _user);
                    userMenu.Run();
                    break;
                case 2:
                    var adminMenu = new AdminMenu(_menu, _services, _user);
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

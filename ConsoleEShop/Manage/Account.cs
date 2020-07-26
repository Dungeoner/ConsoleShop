using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ConsoleEShop.Users;

namespace ConsoleEShop
{
    class Account
    {
        public Account(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        private IDataBase _dataBase; 
        public User Login()
        {
            Console.WriteLine("Enter your username");
            var user = _dataBase.FindUser(Console.ReadLine());
            return user ?? throw new ArgumentException("Wrong username");
        }

        public User Register()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();
            if(_dataBase.FindUser(userName) != null) throw new ArgumentException("Username already exist");
            _dataBase.AddUser(userName);
            return (User)_dataBase.FindUser(userName);
        }

        public User Loguot()
        {
            return new User("Guest", UserType.Guest, 0 );
        }
    }
}

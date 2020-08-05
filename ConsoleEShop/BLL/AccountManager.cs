using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using ConsoleEShop.Enums;

namespace ConsoleEShop
{
    class AccountManager
    {
        public AccountManager(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }
        
        private readonly IDataBase _dataBase;


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

        public void ChangeData(User user)
        {
            if (user.Type == UserType.User)
            {
                Console.WriteLine("Enter new username: ");
                var newUserName = Console.ReadLine() ?? throw new ArgumentException("Username can't be empty");
                user.UserName = newUserName;
            }
            else
            {
                Console.WriteLine("Enter user's name: ");
                var userName = Console.ReadLine() ?? throw new ArgumentException("Username can't be empty");
                var targetUser = _dataBase.FindUser(userName);
                Console.WriteLine("Enter new username: ");
                var newUserName = Console.ReadLine() ?? throw new ArgumentException("Username can't be empty");
                targetUser.UserName = newUserName;
            }
        }

        public void ViewUserData()
        {
            var result = _dataBase.GetUserList();
            foreach (var user in result)
            {
                Console.WriteLine(user);
            }
        }
    }
}

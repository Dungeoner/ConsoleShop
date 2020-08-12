using System;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;

namespace ConsoleEShop.PL.Management
{
    public class AccountManager
    {
        private readonly AccountService _service;

        public AccountManager(AccountService service)
        {
            _service = service;
        }

        public User Login()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();
            return _service.Login(userName);
        }
        public User Register()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();
            return _service.Register(userName);
        }
        public void ChangeData(User user)
        {
            var userType = user.Type;
            if (user.Type == UserType.Admin)
            {
                Console.WriteLine("Enter user's name: ");
                var userName = Console.ReadLine();
                if (userName == string.Empty) throw new UserInputException("Username can't be empty");
                if (!_service.IsExist(userName)) throw new UserInputException("There's no user with this username");
                Console.WriteLine("Select role for this user: \n\t 1 for Admin \n\t 2 for User");
                var result = Console.ReadLine();
                switch (result)
                {
                    case "1":
                        userType = UserType.Admin;
                        break;
                    case "2":
                        break;
                }
            }
            
            Console.WriteLine("Enter new username: ");
            var newUserName = Console.ReadLine();
            _service.ChangeData(user.UserName, newUserName, userType);
        }

        public void ViewUserData()
        {
            var userList = _service.ViewUserData();
            foreach (var user in userList)
            {
                Console.WriteLine($"Username: {user.UserName}| Type: {user.Type}| If: {user.Id}");
            }

        }
    }
}


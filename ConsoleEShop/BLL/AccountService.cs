using System;
using System.Linq;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{
    public class AccountService : Iservice
    {
        public AccountService(CollectionUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Users;
        }
        
        private readonly IRepository<User> _repository;


        public User Login()
        {
            var user = _repository.GetItem(Console.ReadLine());
            return user ?? throw new ArgumentException("Wrong username");
        }

        public User Register()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();
            if(_repository.GetItem(userName) != null) throw new ArgumentException("Username already exist");
            _repository.AddItem(new User(userName, UserType.User, _repository.GetItemList().Count()));
            return _repository.GetItem(userName);
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
                var targetUser = _repository.GetItem(userName);
                Console.WriteLine("Enter new username: ");
                var newUserName = Console.ReadLine() ?? throw new ArgumentException("Username can't be empty");
                targetUser.UserName = newUserName;
            }
        }

        public void ViewUserData()
        {
            var result = _repository.GetItemList();
            foreach (var user in result)
            {
                Console.WriteLine(user);
            }
        }
    }
}

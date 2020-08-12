using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.BLL
{/// <summary>
/// This class 
/// </summary>
    public class AccountService
    {
        public AccountService(IRepositoryUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.Users;
        }

        private readonly IRepository<User> _repository;

        public User Login(string userName)
        {
            if (userName == string.Empty) throw new UserInputException("Username can't be empty");
            var user = _repository.GetItem(userName);
            return user ?? throw new UserInputException("There's no user with this username");
        }


        public User Register(string userName)
        {
            if (_repository.GetItem(userName) != null) throw new UserInputException("Username already exist");
            _repository.AddItem(new User(userName, UserType.User, _repository.ItemCount++));
            return _repository.GetItem(userName);
        }

        public bool IsExist(string userName)
        {
            return _repository.GetItem(userName) != null;
        }

        public void ChangeData(string userName, string newUserName, UserType userType)
        {
            var user = _repository.GetItem(userName);
            if (newUserName == string.Empty) throw new UserInputException("Username can't be empty");
            if (_repository.GetItem(newUserName) != null) throw new UserInputException("Username already exist");
            user.UserName = newUserName;
            user.Type = userType;
        }

        public IEnumerable<User> ViewUserData()
        {
            return _repository.GetItemList();
        }
    }
}

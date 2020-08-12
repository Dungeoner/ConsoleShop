using System.Collections.Generic;
using ConsoleEShop.BLL;
using ConsoleEShop.DAL;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Entities.Enums;
using ConsoleEShop.DAL.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ConsoleEShopTests
{
    public class AccountServiceTests
    { 

        [Test]
        public void Test1()
        {
            //Assert
            var context = NSubstitute.Substitute.For<IRepositoryUnitOfWork>();
            var accountService = new AccountService(context);
            //Act
            accountService.Register("New User1");
            accountService.Register("New User2");
            accountService.Register("New User3");
            var actual =  accountService.ViewUserData();
            var expected = new List<User>
            {
                new User("New User1", UserType.User, 0), new User("New User2", UserType.User, 1),
                new User("New User3", UserType.User, 2)
            };
            Assert.AreEqual(expected, actual);
            Assert.Pass();
        }
    }
}
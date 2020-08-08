using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly CollectionDataBase _context;

        public UserRepository(CollectionDataBase context)
        {
            _context = context;
        }

        public IEnumerable<User> GetItemList()
        {
            return _context.Users;
        }

        public User GetItem(string itemName)
        {
            return _context.Users.Find(x => x.UserName == itemName);
        }

        public void AddItem(User item)
        {
            _context.Users.Add(item);
        }

        public void DeleteItem(User item)
        {
            _context.Users.Remove(item);
        }
    }
}

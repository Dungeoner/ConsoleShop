using System.Collections.Generic;
using ConsoleEShop.DAL.Entities;
using ConsoleEShop.DAL.Interfaces;

namespace ConsoleEShop.DAL.Repositories
{
    /// <summary>
    /// Class used to work with users in Collection database
    /// </summary>
    public class UserRepository : IRepository<User>
    {
        private readonly IDataBase _context;

        public UserRepository(IDataBase context)
        {
            _context = context;
            ItemCount = _context.Users.Count;
        }

        public int ItemCount { get; set; }

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
    }
}

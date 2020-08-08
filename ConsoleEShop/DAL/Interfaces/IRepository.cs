using System.Collections.Generic;

namespace ConsoleEShop.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItemList();
        T GetItem(string itemName);
        void AddItem(T item);
        void DeleteItem(T item);
    }
}

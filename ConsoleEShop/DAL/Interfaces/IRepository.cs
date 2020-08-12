using System.Collections.Generic;

namespace ConsoleEShop.DAL.Interfaces
{
    /// <summary>
    /// Define methods for interaction with database
    /// </summary>
    /// <typeparam name="T">Record in database </typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Number of records in database
        /// </summary>
        int ItemCount { get; set; }
    /// <returns>All records from current database</returns>
        IEnumerable<T> GetItemList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"> Primary key </param>
        /// <returns> One specific record from database by param "itemName" </returns>
        T GetItem(string itemName);
        /// <summary>
        /// Add record to database 
        /// </summary>
        /// <param name="item">Record</param>
        void AddItem(T item);
    }
}

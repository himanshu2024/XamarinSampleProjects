using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkingOnDatabase.Database
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool fourceRefresh = false);
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
    }
}

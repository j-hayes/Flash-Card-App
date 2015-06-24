using System.Collections.Generic;

namespace FlashCardApp.Core.DAL
{
    public interface IRepository<T>
    {
        T GetById(int id);
        
        
        void Delete(T item);
        T Update(T item);
        T Create(T item);
        List<T> Query(string query);
        List<T> GetMatching(string filter);
    }
}

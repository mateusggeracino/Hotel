using System.Collections.Generic;

namespace Hotel.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Insert(T obj);
        T GetById(int id);
        List<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Hotel.Domain.Models;

namespace Hotel.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Insert(T obj);
        T GetById(int id);
        List<T> GetAll();
        void Update(T obj);
        void Remove(T obj);

        List<T> Find(Func<T, bool> predicate);
    }
}

using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hotel.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected static List<T> _data;
        private static object syncObj = new object();

        public Repository()
        {
            if (_data == null)
            {
                lock (syncObj)
                {
                    if (_data == null)
                    {
                        _data = new List<T>();
                    }
                }
            }
        }

        public List<T> GetAll()
        {
            return _data;
        }

        public T GetById(int id)
        {
            return _data.FirstOrDefault(x => x.Id == id);
        }

        public T Insert(T obj)
        {
            obj.Id = _data.Any() ? _data.Max(x => x.Id) + 1 : 1;

            obj.Key = Guid.NewGuid();
            _data.Add(obj);
            return obj;
        }

        public void Remove(T obj)
        {
            _data.Remove(obj);
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return _data.Where(predicate).ToList();
        }

        public void Update(T obj)
        {
            var item = _data.FirstOrDefault(x => x.Key == obj.Key);
            if (item == null) return;

            item = obj;
        }
    }
}

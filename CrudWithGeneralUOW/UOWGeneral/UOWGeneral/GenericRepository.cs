using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace UOWGeneral
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private PersonContaxt entities = null;
        DbSet<T> _objectSet;

        public GenericRepository(PersonContaxt _entities)
        {
            entities = _entities;
            //_objectSet = entities.CreateObjectSet<T>();
            _objectSet = entities.Set<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }

            return _objectSet.AsEnumerable();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Update(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }
    }
}
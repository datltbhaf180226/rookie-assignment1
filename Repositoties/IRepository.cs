using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project1.Repositoties
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        T Get(long id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
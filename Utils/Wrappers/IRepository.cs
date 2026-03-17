using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Utils.Wrappers
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T ReadById(object id);
        IEnumerable<T> ReadMany(Expression<Func<T, bool>> expression = null, params string[] includes);
        void Update(T entity);
        void Delete(T entity);
    }
}

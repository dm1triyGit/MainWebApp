using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T, TEntity>
        where T : class
        where TEntity : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<TEntity, bool> predicate);
        bool Create(T item);
        bool Update(T item);
        bool Delete(T item);
    }
}

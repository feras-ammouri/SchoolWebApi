using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace School.DataAccess.Contracts
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

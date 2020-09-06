using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Interfaces
{
    public interface IRepositoryBase<T>
    {
        T Get(int Id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}

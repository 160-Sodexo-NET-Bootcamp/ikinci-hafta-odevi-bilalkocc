using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.GenericRepo
{
    public interface IGenericRepo<T> where T :class
    {
        Task<IEnumerable<T>> GetAll();
        void Update(T entity);
        void Add(T entity);
        void Delete(T entity);
        Task<T> GetByExp(Expression<Func<T, bool>> expression);

    }
}

using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.GenericRepo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected AppDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepo(AppDbContext context)
        {
            this._context = context;
            dbSet = context.Set<T>();
            
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByExp(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }


        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}

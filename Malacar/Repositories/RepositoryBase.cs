using Malacar.Interfaces;
using Malacar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Malacar.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class 
    {
        protected CarContext CarContext { get; set; }

        public RepositoryBase(CarContext CarContext)
        {
            this.CarContext = CarContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.CarContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.CarContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.CarContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.CarContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.CarContext.Set<T>().Remove(entity);
        }
    }
}

using Malacar.Interfaces;
using Malacar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarContext CarContext { get; set; }

        public RepositoryBase(CarContext carcontext)
        {
            this.CarContext = carcontext;
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

        public void Delete(T entity)
        {
            this.CarContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.CarContext.Set<T>().Update(entity);
        }
    }
}
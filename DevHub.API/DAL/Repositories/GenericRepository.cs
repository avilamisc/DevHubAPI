using DevHub.API.DAL.Interfaces;
using DevHub.API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DevHub.API.DAL.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T>  where T : class
    {
        protected readonly DevHubContext context;
        protected readonly IDbSet<T> dbset;

        public GenericRepository(DevHubContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual T GetByID(int id)
        {
            return dbset.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T entity = dbset.Find(id);
            dbset.Remove(entity);

        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
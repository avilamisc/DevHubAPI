using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
        void Dispose();
    }
}
using DevHub.API.Models;
using DevHub.API.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DevHub.API.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DevHubContext context;

        public CategoryRepository(DevHubContext context)
        {
            this.context = context;
        }


        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }


        public Category GetCategoryByID(int categoryId)
        {
            return context.Categories.Find(categoryId);
        }


        public void InsertCategory(Category category)
        {
            context.Categories.Add(category);
        }


        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }


        public void DeleteCategory(int categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
        }


        public void Save()
        {
            context.SaveChanges();
        }

        #region Dispose

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
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
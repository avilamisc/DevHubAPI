using DevHub.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.Repositories
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryByID(int categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(int categoryId);
        void UpdateCategory(Category category);
        void Save();
    }
}
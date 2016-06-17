using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DevHub.API.Models;
using DevHub.API.Repositories;
using DevHub.API.DAL.Repositories;

namespace DevHub.API.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryRepository repo;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.repo = categoryRepository;
        }

        // GET: api/Categories
        public IEnumerable<Category> GetCategories()
        {
            return repo.GetCategories();
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = repo.GetCategoryByID(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            repo.UpdateCategory(category);

            try
            {
                repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.InsertCategory(category);
            repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = repo.GetCategoryByID(id);
            if (category == null)
            {
                return NotFound();
            }

            repo.DeleteCategory(id);
            repo.Save();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
        }
    }
}
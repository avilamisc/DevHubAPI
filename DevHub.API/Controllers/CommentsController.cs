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
using DevHub.API.DAL.Interfaces;

namespace DevHub.API.Controllers
{
    public class CommentsController : ApiController
    {
        private ICommentRepository repo;

        public CommentsController(ICommentRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/Comments
        public IEnumerable<Comment> GetComments()
        {
            return repo.GetAll();
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = repo.GetByID(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            repo.Update(comment);

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

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Insert(comment);
            repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = repo.GetByID(id);
            if (comment == null)
            {
                return NotFound();
            }

            repo.Delete(id);
            repo.Save();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
        }
    }
}
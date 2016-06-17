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

namespace DevHub.API.Controllers
{
    public class CoursesController : ApiController
    {
        private ICourseRepository repo;

        public CoursesController(ICourseRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/Courses
        public IEnumerable<Course> GetCourses()
        {
            return repo.GetCourses();
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = repo.GetCourseByID(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            repo.UpdateCourse(course);

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

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.InsertCourse(course);
            repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = repo.GetCourseByID(id);
            if (course == null)
            {
                return NotFound();
            }

            repo.DeleteCourse(id);
            repo.Save();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
        }
    }
}
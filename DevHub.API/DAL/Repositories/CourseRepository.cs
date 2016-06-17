using DevHub.API.Models;
using DevHub.API.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DevHub.API.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DevHubContext context;

        public CourseRepository(DevHubContext context)
        {
            this.context = context;
        }


        public IEnumerable<Course> GetCourses()
        {
            return context.Courses.ToList();
        }


        public Course GetCourseByID(int courseId)
        {
            return context.Courses.Find(courseId);
        }


        public void InsertCourse(Course course)
        {
            context.Courses.Add(course);
        }


        public void UpdateCourse(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
        }


        public void DeleteCourse(int courseId)
        {
            Course course = context.Courses.Find(courseId);
            context.Courses.Remove(course);
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
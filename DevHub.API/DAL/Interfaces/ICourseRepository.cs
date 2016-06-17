using DevHub.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.Repositories
{
    public interface ICourseRepository : IDisposable
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseByID(int courseId);
        void InsertCourse(Course course);
        void DeleteCourse(int courseId);
        void UpdateCourse(Course course);
        void Save();
    }
}
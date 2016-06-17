using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Message { get; set; }

        //Lazy Loading
        public virtual Course Course { get; set; }
    }
}
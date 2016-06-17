using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int CourseId { get; set; }

        public string Title { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
        public int Lesson { get; set; }
        public byte[] Photo { get; set; }

        //Lazy Loading
        public virtual Course Course { get; set; }
    }
}
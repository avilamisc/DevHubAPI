using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevHub.API.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public bool IsValid { get; set; }
        public byte[] Photo { get; set; }

        // Lazy Loading
        
        public virtual Category Category { get; set; }
        //public virtual IEnumerable<Video> Videos { get; set; }
        //public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
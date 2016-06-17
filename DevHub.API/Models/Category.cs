using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevHub.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(7)]
        public string Color { get; set; }
        public byte[] Icon { get; set; }

        // Lazy Loading
        public virtual ICollection<Course> Courses { get; set; }
    }
}
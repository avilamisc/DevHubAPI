using System.Data.Entity;

namespace DevHub.API.Models
{
    public class DevHubContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        //public DevHubContext() : base("name=DevHubContext")
        //{
        //}
        
        public DevHubContext() : base("name=DevHub_GEAR")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}

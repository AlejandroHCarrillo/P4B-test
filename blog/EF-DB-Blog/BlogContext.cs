using Microsoft.EntityFrameworkCore;

namespace EF_DB_Blog
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) {
            
        }

        public DbSet<Post> Posts { get; set; }

    }
}
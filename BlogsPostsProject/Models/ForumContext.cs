using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsPostsProject.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions options):
            base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasMany(p => p.Posts)
                .WithOne().HasForeignKey(b => b.PostId);
            base.OnModelCreating(builder);
        }
    }
}

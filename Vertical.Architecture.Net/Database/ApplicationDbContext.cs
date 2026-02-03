using Microsoft.EntityFrameworkCore;
using Vertical.Architecture.Net.Entities;

namespace Vertical.Architecture.Net.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(builder =>
                builder.OwnsOne(a => a.Tags, tagsBuilder => tagsBuilder.ToJson()));
        }

        public DbSet<Article> Articles { get; set; }
    }
}
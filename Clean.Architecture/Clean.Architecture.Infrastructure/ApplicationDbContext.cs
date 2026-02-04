using Clean.Architecture.Domain.Abstractions;
using Clean.Architecture.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        public DbSet<Webinar> Webinars { get; set; }
    }
}

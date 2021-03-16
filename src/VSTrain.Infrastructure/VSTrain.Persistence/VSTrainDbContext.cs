using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VSTrain.Core.Common;
using VSTrain.Core.Entities;

namespace VSTrain.Persistence
{
    public class VSTrainDbContext : DbContext
    {
        public VSTrainDbContext(DbContextOptions<VSTrainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VSTrainDbContext).Assembly);
            modelBuilder.Entity<Course>().HasData(
                                                  new Course() { Id = 1, Name = "Scrum for Product Owners" },
                                                  new Course() { Id = 2, Name = "ASP.NET Core 6.0" }
                                                  );

        }
        public DbSet<Course> Courses;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<Base>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTimeOffset.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }

}
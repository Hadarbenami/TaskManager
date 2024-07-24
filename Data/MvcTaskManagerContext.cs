using Microsoft.EntityFrameworkCore;

namespace MvcTaskManager.Models
{
    public class MvcTaskManagerContext : DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        public MvcTaskManagerContext(DbContextOptions<MvcTaskManagerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTask>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd(); // Ensure Id is auto-generated

            modelBuilder.Entity<MyTask>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()"); // Set default value to current date

            modelBuilder.Entity<MyTask>()
                .Property(t => t.Priority)
                .HasConversion<string>(); // Convert enum to string for database storage

            modelBuilder.Entity<MyTask>()
                .Property(t => t.Title)
                .IsRequired(); // Ensure Title is required
        }
    }
}

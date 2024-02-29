using Microsoft.EntityFrameworkCore;

namespace StudentEnrollmentSystem.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(s => s.stud_id); // Specifies Stud_Id as the primary key

        // Other configurations...

    }

        public DbSet<Student> Students { get; set; }
    }
}
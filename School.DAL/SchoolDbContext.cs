using School.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace School.DAL
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Classroom)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassroomId)
                .OnDelete(DeleteBehavior.SetNull);
        }

    }
}

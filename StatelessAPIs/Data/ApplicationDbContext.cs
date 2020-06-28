using Microsoft.EntityFrameworkCore;
using StatelessAPIs.Models.Dtos;
using System;

namespace StatelessAPIs.Data
{
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseTeacher> CourseTeacher { get; set; }
        public DbSet<StudentAdviser> StudentAdviser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Course>()
            .Property(p => p.Level)
            .HasConversion(
                v => v.ToString(),
                v => (CourseLevel)Enum.Parse(typeof(CourseLevel), v));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MVC_Day1.Data.Configurations;
using MVC_Day1.Models;
using System.Collections.Generic;

namespace MVC_Day1.Data.Context
{
    public class TaskDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VMQPVJ0;Initial Catalog=Task;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StuCrsRes> StuCrsRess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new StuCrsResConfiguration());
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.dept)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}

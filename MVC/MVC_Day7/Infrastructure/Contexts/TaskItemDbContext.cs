using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Contexts
{
    public class TaskItemDbContext : DbContext
    {
        public TaskItemDbContext(DbContextOptions<TaskItemDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-VMQPVJ0;Initial Catalog=TaskItem7;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //}
        public DbSet<TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskItemDbContext).Assembly);
        }
    }
}

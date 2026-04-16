using EFCoreDay02.Project02.Context;
using EFCoreDay02.Project02.Models;
using EFCoreDay02.Project03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project03.Contexts
{
    internal class Project03DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-VMQPVJ0;Database=Project03;Trusted_Connection=True;TrustServerCertificate = True");
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder b)
        {
            b.ApplyConfigurationsFromAssembly(typeof(Project03DbContext).Assembly);
        }
    }
}

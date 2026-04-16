using EFCoreDay02.Project03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project03.Configurations
{
    internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> b)
        {
            b.HasMany(p => p.Appointments)
             .WithOne(a => a.Patient)
             .HasForeignKey(a => a.PatientId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

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
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> b)
        {
            b.HasMany(d => d.Appointments)
             .WithOne(a => a.Doctor)
             .HasForeignKey(a => a.DoctorId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

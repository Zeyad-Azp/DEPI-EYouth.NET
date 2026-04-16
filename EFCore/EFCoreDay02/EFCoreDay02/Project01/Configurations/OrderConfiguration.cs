using EFCoreDay02.Project01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project01.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> b)
        {
            b.HasMany(o => o.OrderDetails)
                 .WithOne(o => o.Order)
                 .HasForeignKey(o => o.OrderId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

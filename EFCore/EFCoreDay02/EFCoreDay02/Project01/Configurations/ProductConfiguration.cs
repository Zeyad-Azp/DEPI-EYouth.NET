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
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
                b.HasMany(p => p.OrderDetails)
                 .WithOne(o => o.Product)
                 .HasForeignKey(o => o.ProductId)
                 .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

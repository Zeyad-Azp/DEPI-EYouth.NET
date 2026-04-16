using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Day1.Models;

namespace MVC_Day1.Data.Configurations
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {           // EntityTypeBuilder
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            // Primary Key
            builder.HasKey(s => s.Id);

            // Properties
            builder.Property(s => s.Name)
                  .HasMaxLength(100);

            builder.Property(s => s.Age)
                  .HasMaxLength(100);

            // Relationship
            builder.HasOne(s => s.dept)
                  .WithMany(d => d.Students)
                  .HasForeignKey(s => s.DepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

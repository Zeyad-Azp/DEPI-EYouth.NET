using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Day6.Models;

namespace MVC_Day6.Data.Configurations
{
    public class StuCrsResConfiguration : IEntityTypeConfiguration<StuCrsRes>
    {
                // EntityTypeBuilder
        public void Configure(EntityTypeBuilder<StuCrsRes> builder)
        {
            builder.ToTable("StuCrsRess");
            // Composite Key
            builder.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });
            builder.HasOne(sc => sc.course)
                  .WithMany(c => c.StudentCourse)
                  .HasForeignKey(sc => sc.CourseId)
                  .OnDelete(DeleteBehavior.Restrict);

        }
        
    }
}

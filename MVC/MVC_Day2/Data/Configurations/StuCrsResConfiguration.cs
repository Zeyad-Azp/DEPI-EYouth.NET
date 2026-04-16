using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Day1.Models;

namespace MVC_Day1.Data.Configurations
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

        }
        
    }
}

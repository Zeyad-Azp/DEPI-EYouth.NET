using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Day5.Models;

namespace MVC_Day5.Data.Configurations
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

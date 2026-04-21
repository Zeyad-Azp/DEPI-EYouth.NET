using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InfraStructure.Configurations
{
    internal class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("TaskItems");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            builder.Property(t => t.Description)
                    .IsRequired()
                    .HasMaxLength(500);
            builder.Property(t => t.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
            builder.Property(t => t.IsCompleted)
                    .IsRequired();
            builder.Property(t => t.DueDate)
                    .IsRequired(false);
        }
    }
}

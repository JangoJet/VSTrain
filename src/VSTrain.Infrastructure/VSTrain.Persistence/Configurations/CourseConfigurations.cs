using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSTrain.Core.Entities;

namespace VSTrain.Persistence.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c =>c.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(b => b.Title)
                .IsRequired();

            builder
               .Property(b => b.Description)
               .IsRequired();

            builder
               .Property(b => b.Level)
               .IsRequired();

            builder
               .Property(b => b.Specialization)
               .IsRequired();
        }
    }
}

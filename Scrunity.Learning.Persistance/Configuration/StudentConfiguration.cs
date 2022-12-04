using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(b => b.FullName)
                .IsRequired();

            builder
               .Property(b => b.Email)
               .IsRequired();

            builder
               .Property(b => b.Phone)
               .IsRequired();

            builder
               .Property(b => b.BirthDate)
               .IsRequired();
        }
    }
}

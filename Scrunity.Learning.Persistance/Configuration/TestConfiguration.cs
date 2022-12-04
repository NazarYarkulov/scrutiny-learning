using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(b => b.Article)
                .WithOne(b => b.Test);

            builder
                .Property(b => b.Title)
                .IsRequired();

            builder
               .Property(b => b.SuccessfulRating)
               .IsRequired();

            builder
               .Property(b => b.RetryCount)
               .IsRequired();
        }
    }
}

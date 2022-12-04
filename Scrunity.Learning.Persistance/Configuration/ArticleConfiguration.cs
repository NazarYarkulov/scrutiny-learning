using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(b => b.Course)
                .WithMany(b => b.Articles)
                .HasForeignKey(b => b.CourseId);

            builder
                .Property(b => b.Title)
                .IsRequired();

            builder
               .Property(b => b.Text)
               .IsRequired();

        }
    }
}

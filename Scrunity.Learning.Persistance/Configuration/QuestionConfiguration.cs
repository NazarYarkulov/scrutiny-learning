using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(b => b.Test)
                .WithMany(b => b.Questions)
                .HasForeignKey(b => b.TestId);

            builder
                .Property(b => b.Text)
                .IsRequired();
        }
    }
}

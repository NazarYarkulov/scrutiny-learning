using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    internal class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(b => b.Question)
                .WithMany(b => b.Answers)
                .HasForeignKey(b => b.QuestionId);

            builder
                .Property(b => b.Text)
                .IsRequired();
        }
    }
}

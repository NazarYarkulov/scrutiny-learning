using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Configuration
{
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder
                .HasKey(b => new { b.StudentId, b.CourseId });

            builder
                .HasOne(b => b.Student)
                .WithMany(b => b.StudentCourses)
                .HasForeignKey(bc => bc.StudentId);

            builder
                .HasOne(b => b.Course)
                .WithMany(b => b.StudentCourses)
                .HasForeignKey(bc => bc.CourseId);

            builder
               .Property(b => b.Status)
               .IsRequired();

            builder
                .Property(b => b.StartDate)
                .IsRequired();
        }
    }
}

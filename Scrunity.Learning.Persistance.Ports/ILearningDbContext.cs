using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;

namespace Scrunity.Learning.Persistance.Ports
{
    public interface ILearningDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
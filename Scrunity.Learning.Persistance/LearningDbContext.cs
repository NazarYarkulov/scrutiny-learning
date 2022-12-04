using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Persistance
{
    public class LearningDbContext : DbContext, ILearningDbContext
    {
        public LearningDbContext(DbContextOptions<LearningDbContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LearningDbContext).Assembly);
        }
    }
}

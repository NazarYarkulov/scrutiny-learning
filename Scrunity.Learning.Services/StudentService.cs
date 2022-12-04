using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services
{
    public class StudentService : IStudentService
    {
        private readonly ILearningDbContext _learningDbContext;
        public StudentService(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<ICollection<Student>> GetStudents(StudentQueryFilter filter, CancellationToken cancellationToken)
        {
            var query = _learningDbContext
                .Students
                .AsQueryable();
            if (!string.IsNullOrEmpty(filter.FullName))
                query = query.Where(x => x.FullName.Contains(filter.FullName));

            if (filter.SortByAscending) query = query.OrderBy(x => x.FullName);
            else query = query.OrderByDescending(x => x.FullName);

            return await query.ToArrayAsync(cancellationToken);
        }
    }
    public interface IStudentService
    {
        Task<ICollection<Student>> GetStudents(StudentQueryFilter filter, CancellationToken cancellationToken);
    }
}

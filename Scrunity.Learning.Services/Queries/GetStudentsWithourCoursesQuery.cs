using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Queries
{
    public class GetStudentsWithourCoursesQuery : IRequest<ICollection<Student>>
    {

    }

    internal class GetStudentsWithourCoursesQueryHandler : IRequestHandler<GetStudentsWithourCoursesQuery, ICollection<Student>>
    {
        private readonly ILearningDbContext _learningDbContext;
        public GetStudentsWithourCoursesQueryHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<ICollection<Student>> Handle(GetStudentsWithourCoursesQuery request, CancellationToken cancellationToken)
        {
            var query = _learningDbContext
                .Students
                .AsQueryable()
                .Include(x => x.StudentCourses).DefaultIfEmpty()
                .Where(x => !x.StudentCourses.Any());
            return await query.ToArrayAsync(cancellationToken);
        }
    }
}

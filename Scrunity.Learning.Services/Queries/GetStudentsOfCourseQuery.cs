using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Queries
{
    public class GetStudentsOfCourceQuery : IRequest<ICollection<Student>>
    {
        public int CourseId { get; }
        public GetStudentsOfCourceQuery(int courseId)
        {
            CourseId = courseId;
        }
    }

    public class GetStudentsOfCourceQueryHandler : IRequestHandler<GetStudentsOfCourceQuery, ICollection<Student>>
    {
        private readonly ILearningDbContext _learningDbContext;
        public GetStudentsOfCourceQueryHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<ICollection<Student>> Handle(GetStudentsOfCourceQuery request, CancellationToken cancellationToken)
        {
            var query = _learningDbContext
                .StudentCourses
                .AsQueryable()
                .Include(x => x.Student)
                .Where(x => x.CourseId == request.CourseId)
                .Select(x => x.Student);

            return await query.ToArrayAsync(cancellationToken);
        }
    }
}

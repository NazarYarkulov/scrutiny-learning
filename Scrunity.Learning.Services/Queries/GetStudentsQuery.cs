using MediatR;
using Microsoft.EntityFrameworkCore;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Queries
{
    public class GetStudentsQuery : IRequest<ICollection<Student>>
    {
        public StudentQueryFilter Filter { get; }
        public GetStudentsQuery(StudentQueryFilter filter)
        {
            Filter = filter;
        }
    }

    internal class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, ICollection<Student>>
    {
        private readonly ILearningDbContext _learningDbContext;
        public GetStudentsQueryHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<ICollection<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var query = _learningDbContext
                .Students
                .AsQueryable()
                .Where(x => x.FullName.Contains(request.Filter.FullName));

            if (request.Filter.SortByAscending) query = query.OrderBy(x => x.FullName);
            else query = query.OrderByDescending(x => x.FullName);

            return await query.ToArrayAsync(cancellationToken);
        }
    }
}

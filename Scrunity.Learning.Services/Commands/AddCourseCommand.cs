using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddCourseCommand : IRequest
    {
        public AddCourseCommand(Course course)
        {
            Course = course;
        }

        public Course Course { get; }
    }

    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddCourseCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Courses.Add(request.Course);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

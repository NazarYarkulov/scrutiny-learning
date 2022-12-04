using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddStudentCourseCommand : IRequest
    {
        public AddStudentCourseCommand(StudentCourse studentCourse)
        {
            StudentCourse = studentCourse;
        }

        public StudentCourse StudentCourse { get; }
    }

    public class AddStudentCourseCommandHandler : IRequestHandler<AddStudentCourseCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddStudentCourseCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddStudentCourseCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.StudentCourses.Add(request.StudentCourse);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

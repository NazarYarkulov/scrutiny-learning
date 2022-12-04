using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddStudentCommand : IRequest
    {
        public AddStudentCommand(Student student)
        {
            Student = student;
        }

        public Student Student { get; }
    }

    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddStudentCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Students.Add(request.Student);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

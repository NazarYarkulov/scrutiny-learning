using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddTestCommand : IRequest
    {
        public AddTestCommand(Test test)
        {
            Test = test;
        }

        public Test Test { get; }
    }

    public class AddTestCommandHandler : IRequestHandler<AddTestCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddTestCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Tests.Add(request.Test);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

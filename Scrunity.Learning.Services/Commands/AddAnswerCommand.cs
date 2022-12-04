using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddAnswerCommand : IRequest
    {
        public AddAnswerCommand(Answer answer)
        {
            Answer = answer;
        }

        public Answer Answer { get; }
    }

    public class AddAnswerCommandHandler : IRequestHandler<AddAnswerCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddAnswerCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Answers.Add(request.Answer);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

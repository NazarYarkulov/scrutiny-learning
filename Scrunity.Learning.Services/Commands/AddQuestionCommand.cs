using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddQuestionCommand : IRequest
    {
        public AddQuestionCommand(Question question)
        {
            Question = question;
        }

        public Question Question { get; }
    }

    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddQuestionCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Questions.Add(request.Question);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

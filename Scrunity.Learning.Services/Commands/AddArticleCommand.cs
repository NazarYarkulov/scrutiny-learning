using MediatR;
using Scrunity.Learnig.Entities;
using Scrunity.Learning.Persistance.Ports;

namespace Scrunity.Learning.Services.Commands
{
    public class AddArticleCommand : IRequest
    {
        public AddArticleCommand(Article article)
        {
            Article = article;
        }

        public Article Article { get; }
    }

    public class AddArticleCommandHandler : IRequestHandler<AddArticleCommand>
    {
        private readonly ILearningDbContext _learningDbContext;
        public AddArticleCommandHandler(ILearningDbContext learningDbContext)
        {
            _learningDbContext = learningDbContext;
        }

        public async Task<Unit> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            _learningDbContext.Articles.Add(request.Article);
            await _learningDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

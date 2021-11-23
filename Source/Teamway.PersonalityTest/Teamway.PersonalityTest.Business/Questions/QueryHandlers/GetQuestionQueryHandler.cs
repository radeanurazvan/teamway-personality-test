using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    internal sealed class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, Maybe<QuestionModel>>
    {
        private readonly IRepository<Question> questionsRepository;

        public GetQuestionQueryHandler(IRepository<Question> questionsRepository)
        {
            this.questionsRepository = questionsRepository;
        }

        public Task<Maybe<QuestionModel>> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var modelOrNothing = questionsRepository.GetOne(q => q.Id == request.QuestionId).Map(q => q.ToModel());

            return Task.FromResult(modelOrNothing);
        }
    }
}
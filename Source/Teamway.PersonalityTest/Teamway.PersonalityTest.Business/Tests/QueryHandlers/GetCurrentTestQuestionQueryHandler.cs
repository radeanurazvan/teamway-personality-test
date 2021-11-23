using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    internal sealed class GetCurrentTestQuestionQueryHandler : IRequestHandler<GetCurrentTestQuestionQuery, Maybe<QuestionModel>>
    {
        private readonly IRepository<Test> testsRepository;
        private readonly IRepository<Question> questionsRepository;

        public GetCurrentTestQuestionQueryHandler(IRepository<Test> testsRepository, IRepository<Question> questionsRepository)
        {
            this.testsRepository = testsRepository;
            this.questionsRepository = questionsRepository;
        }

        public Task<Maybe<QuestionModel>> Handle(GetCurrentTestQuestionQuery request, CancellationToken cancellationToken)
        {
            var questionOrNothing = testsRepository.GetOne(t => t.Id == request.TestId)
                .Map(t => t.GetCurrentQuestion())
                .Bind(cq => questionsRepository.GetOne(q => q.Id == cq))
                .Map(q => q.ToModel());

            return Task.FromResult(questionOrNothing);
        }
    }
}
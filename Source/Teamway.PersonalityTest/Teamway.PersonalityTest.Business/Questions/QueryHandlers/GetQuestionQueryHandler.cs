using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
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
            var modelOrNothing = questionsRepository.GetOne(q => q.Id == request.QuestionId).Map(q => new QuestionModel
            {
                Id = q.Id,
                Text = q.Text,
                Answers = q.Answers.Select(a => new QuestionAnswerModel
                {
                    Id = a.Id,
                    Text = a.Text
                }).ToList()
            });

            return Task.FromResult(modelOrNothing);
        }
    }
}
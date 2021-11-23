using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    internal sealed class AnswerTestQuestionCommandHandler : IRequestHandler<AnswerTestQuestionCommand, Result<AnswerTestQuestionResult>>
    {
        private readonly IRepository<Test> testsRepository;
        private readonly IRepository<Question> questionsRepository;

        public AnswerTestQuestionCommandHandler(IRepository<Test> testsRepository, IRepository<Question> questionsRepository)
        {
            this.testsRepository = testsRepository;
            this.questionsRepository = questionsRepository;
        }

        public Task<Result<AnswerTestQuestionResult>> Handle(AnswerTestQuestionCommand request, CancellationToken cancellationToken)
        {
            var testResult = testsRepository.GetOne(t => t.Id == request.TestId).ToResult("Test not found");
            var answerResult = questionsRepository.GetOne(q => q.Id == request.QuestionId).ToResult("Question not found")
                .Bind(q => q.GetAnswer(request.AnswerId).ToResult("Answer not found"));

            var result = Result.FirstFailureOrSuccess(testResult, answerResult)
                .Bind(() => testResult.Value.Answer(request.QuestionId, answerResult.Value))
                .Tap(() => testsRepository.SaveChanges())
                .Map(() => new AnswerTestQuestionResult(testResult.Value.IsFinished(), testResult.Value.GetCurrentQuestion()));

            return Task.FromResult(result);
        }
    }
}
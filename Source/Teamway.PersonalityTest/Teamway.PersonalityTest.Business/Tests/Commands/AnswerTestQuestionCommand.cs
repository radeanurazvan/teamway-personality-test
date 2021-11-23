using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace Teamway.PersonalityTest.Business
{
    public sealed class AnswerTestQuestionCommand : IRequest<Result<AnswerTestQuestionResult>>
    {
        public AnswerTestQuestionCommand(Guid testId, Guid questionId, Guid answerId)
        {
            TestId = testId;
            QuestionId = questionId;
            AnswerId = answerId;
        }

        public Guid TestId { get; private set; }

        public Guid QuestionId { get; private set; }

        public Guid AnswerId { get; private set; }
    }
}
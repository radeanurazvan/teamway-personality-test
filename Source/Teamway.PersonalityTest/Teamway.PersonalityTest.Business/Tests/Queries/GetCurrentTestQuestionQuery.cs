using System;
using MediatR;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Business
{
    public sealed class GetCurrentTestQuestionQuery : IRequest<Maybe<QuestionModel>>
    {
        public GetCurrentTestQuestionQuery(Guid testId)
        {
            TestId = testId;
        }

        public Guid TestId { get; private set; }
    }
}
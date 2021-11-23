using System;
using MediatR;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Business
{
    public sealed class GetQuestionQuery : IRequest<Maybe<QuestionModel>>
    {
        public GetQuestionQuery(Guid questionId)
        {
            QuestionId = questionId;
        }

        public Guid QuestionId { get; private set; }
    }
}
using System;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Business
{
    public sealed class AnswerTestQuestionResult
    {
        public AnswerTestQuestionResult(bool finished, Maybe<Guid> nextQuestion)
        {
            Finished = finished;
            NextQuestion = nextQuestion.Map(v => (Guid?)v).GetValueOrDefault();
        }

        public Guid? NextQuestion { get; private set; }

        public bool Finished { get; private set; }
    }
}
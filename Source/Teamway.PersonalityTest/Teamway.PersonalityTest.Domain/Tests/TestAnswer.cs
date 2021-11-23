using System;
using System.Linq;
using System.Collections.Generic;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class TestAnswer : Entity
    {
        private TestAnswer()
        {
        }

        internal TestAnswer(Guid testId, Guid questionId, QuestionAnswer answer)
        {
            TestId = testId;
            QuestionId = questionId;
            AnswerId = answer.Id;

            Impacts = answer.Impacts.Select(i => new TestAnswerImpact(i.ImpactedType, i.ScoreImpact)).ToList();
        }

        public Guid TestId { get; private set; }

        public Guid QuestionId { get; private set; }

        public Guid AnswerId { get; private set; }

        public IEnumerable<TestAnswerImpact> Impacts { get; private set; }
    }
}
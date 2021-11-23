using System;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class TestQuestion : Entity
    {
        private TestQuestion()
        {
        }

        internal TestQuestion(Guid testId, Guid questionId) : this()
        {
            TestId = testId;
            QuestionId = questionId;
        }

        public Guid TestId { get; private set; }

        public Guid QuestionId { get; private set; }
    }
}
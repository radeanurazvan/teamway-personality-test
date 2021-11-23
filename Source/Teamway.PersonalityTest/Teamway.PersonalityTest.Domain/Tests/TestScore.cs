using System;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class TestScore : Entity
    {
        private TestScore()
        {
        }

        internal TestScore(Guid testId, PersonalityTypes type, int score) : this()
        {
            TestId = testId;
            Type = type;
            Score = score;
        }

        public Guid TestId { get; private set; }

        public PersonalityTypes Type { get; private set; }

        public int Score { get; private set; }
    }
}
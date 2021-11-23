namespace Teamway.PersonalityTest.Domain
{
    public sealed class TestAnswerImpact : Entity
    {
        private TestAnswerImpact()
        {
        }

        internal TestAnswerImpact(PersonalityTypes impactedType, int scoreImpact)
        {
            ImpactedType = impactedType;
            ScoreImpact = scoreImpact;
        }

        public PersonalityTypes ImpactedType { get; private set; }

        public int ScoreImpact { get; private set; }
    }
}
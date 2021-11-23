using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class QuestionAnswerImpact : Entity
    {
        private QuestionAnswerImpact()
        {
        }

        private QuestionAnswerImpact(PersonalityTypes impactedType, int scoreImpact) : this()
        {
            ImpactedType = impactedType;
            ScoreImpact = scoreImpact;
        }

        public static QuestionAnswerImpact Extrovert(int impact) => new QuestionAnswerImpact(PersonalityTypes.Extrovert, impact);
        
        public static QuestionAnswerImpact Introvert(int impact) => new QuestionAnswerImpact(PersonalityTypes.Introvert, impact);

        public PersonalityTypes ImpactedType { get; private set; }

        public int ScoreImpact { get; private set; }
    }
}
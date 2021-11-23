using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    public sealed class TestScoreModel
    {
        public PersonalityTypes PersonalityType { get; set; }

        public int Score { get; set; }
    }
}
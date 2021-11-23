using System.Collections.Generic;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Tests
{
    public static class QuestionsFactory
    {
        public static Question Any() => Question.Create("Q1", new List<QuestionAnswer> { QuestionAnswer.Create("A1", new List<QuestionAnswerImpact> { QuestionAnswerImpact.Introvert(10) }).Value }).Value;
    }
}
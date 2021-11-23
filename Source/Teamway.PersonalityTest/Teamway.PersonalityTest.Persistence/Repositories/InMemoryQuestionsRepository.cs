using System.Collections.Generic;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Persistence
{
    internal sealed class InMemoryQuestionsRepository : InMemoryRepository<Question>
    {
        protected override IEnumerable<Question> GetInitialState() => new List<Question>
        {
            Question.Create("You’re really busy at work and a colleague is telling you their life story and personal woes. You:", new List<QuestionAnswer>
            {
                QuestionAnswer.Create("Don’t dare to interrupt them", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Introvert(10) }).Value,
                QuestionAnswer.Create("Think it’s more important to give them some of your time; work can wait", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(5) }).Value,
                QuestionAnswer.Create("Listen, but with only with half an ear", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(10) }).Value,
                QuestionAnswer.Create("Interrupt and explain that you are really busy at the moment", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(20) }).Value,
            }).Value,

            Question.Create("You’ve been sitting in the doctor’s waiting room for more than 25 minutes. You:", new List<QuestionAnswer>
            {
                QuestionAnswer.Create("Look at your watch every two minutes", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Introvert(10) }).Value,
                QuestionAnswer.Create("Bubble with inner anger, but keep quiet", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Introvert(15) }).Value,
                QuestionAnswer.Create("Explain to other equally impatient people in the room that the doctor is always running late", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(10), QuestionAnswerImpact.Introvert(5) }).Value,
                QuestionAnswer.Create("Complain in a loud voice, while tapping your foot impatiently", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(20) }).Value,
            }).Value,

            Question.Create("You’re having an animated discussion with a colleague regarding a project that you’re in charge of. You:", new List<QuestionAnswer>
            {
                QuestionAnswer.Create("Don’t dare contradict them", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Introvert(10) }).Value,
                QuestionAnswer.Create("Think that they are obviously right", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(5) }).Value,
                QuestionAnswer.Create("Defend your own point of view, tooth and nail", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(15) }).Value,
                QuestionAnswer.Create("Continuously interrupt your colleague", new List<QuestionAnswerImpact>{ QuestionAnswerImpact.Extrovert(20) }).Value,
            }).Value,
        };
    }
}
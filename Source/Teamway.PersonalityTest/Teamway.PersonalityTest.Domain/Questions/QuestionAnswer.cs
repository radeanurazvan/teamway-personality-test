using System.Linq;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain.Extensions;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class QuestionAnswer : Entity
    {
        private readonly ICollection<QuestionAnswerImpact> impacts = new List<QuestionAnswerImpact>();

        private QuestionAnswer()
        {
        }

        public QuestionAnswer(string text, IEnumerable<QuestionAnswerImpact> impacts)
        {
            Text = text;
            this.impacts = impacts.ToList();
        }

        public static Result<QuestionAnswer> Create(string text, IEnumerable<QuestionAnswerImpact> impacts)
        {
            var textResult = text.EnsureValidString("You must provide a valid text for an answer!");
            var impactsResult = impacts.EnsureNotNull("You must provide a valid list of impacts!")
                .Ensure(i => i.Any(), "You must provide a non-empty list of impacts!");

            return Result.FirstFailureOrSuccess(textResult, impactsResult)
                .Map(() => new QuestionAnswer(text, impacts));
        }

        public string Text { get; private set; }

        public IEnumerable<QuestionAnswerImpact> Impacts => this.impacts;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain.Extensions;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class Question : AggregateRoot
    {
        private readonly ICollection<QuestionAnswer> answers = new List<QuestionAnswer>();

        private Question()
        {
        }

        private Question(string text, IEnumerable<QuestionAnswer> answers) 
            : this()
        {
            Text = text;
            this.answers = answers.ToList();
        }

        public static Result<Question> Create(string text, IEnumerable<QuestionAnswer> answers)
        {
            var textResult = text.EnsureValidString("You must provide a valid text for the question!");
            var answersResult = text.EnsureNotNull("You must provide a valid list of answers!")
                .Ensure(a => a.Any(), "You must prove a non-empty list of answers!");

            return Result.FirstFailureOrSuccess(textResult, answersResult)
                .Map(() => new Question(text, answers));
        }

        public string Text { get; private set; }

        public IEnumerable<QuestionAnswer> Answers => answers;

        public Maybe<QuestionAnswer> GetAnswer(Guid id) => answers.TryFirst(a => a.Id == id);
    }
}
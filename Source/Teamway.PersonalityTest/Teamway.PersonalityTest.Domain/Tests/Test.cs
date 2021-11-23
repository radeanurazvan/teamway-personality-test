using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain.Extensions;

namespace Teamway.PersonalityTest.Domain
{
    public sealed class Test : AggregateRoot
    {
        private readonly ICollection<TestScore> scores = new List<TestScore>();
        private readonly ICollection<TestAnswer> answers = new List<TestAnswer>();
        private readonly ICollection<TestQuestion> questions = new List<TestQuestion>();

        private Test()
        {
        }

        private Test(IEnumerable<Question> questions) : this()
        {
            this.questions = questions.Select(q => new TestQuestion(Id, q.Id)).ToList();
        }

        public static Result<Test> Create(IEnumerable<Question> questions)
        {
            return questions.EnsureNotNull("You must provide a valid list of questions for the test!")
                .Ensure(q => q.Any(), "You must provide a non-empty list of questions!")
                .Map(q => new Test(q));
        }

        public Result Answer(Guid questionId, QuestionAnswer answer)
        {
            if (IsFinished())
            {
                return Result.Failure("You already finished this test!");
            }

            var duplicateAnswer = answers.TryFirst(a => a.QuestionId == questionId);
            if (duplicateAnswer.HasValue)
            {
                return Result.Success();
            }

            return answer.EnsureNotNull("You must provide a valid answer!")
                .Map(a => new TestAnswer(Id, questionId, a))
                .Tap(ta => answers.Add(ta))
                .Tap(ComputeScore);
        }

        public Maybe<Guid> GetNextQuestion()
        {
            var answeredQuestions = answers.Select(a => a.QuestionId);
            return questions.TryFirst(q => !answeredQuestions.Contains(q.Id))
                .Map(q => q.QuestionId);
        }

        public bool IsFinished()
        {
            var allQuestions = questions.Select(q => q.QuestionId);
            var answeredQuestions = answers.Select(a => a.QuestionId);

            return allQuestions.SequenceEqual(answeredQuestions);
        }

        private void ComputeScore()
        {
            var newScores = answers.SelectMany(a => a.Impacts)
                .ToLookup(i => i.ImpactedType)
                .Select(g => new TestScore(Id, g.Key, g.Sum(i => i.ScoreImpact)))
                .ToList();

            this.scores.Clear();
            foreach (var score in newScores)
            {
                this.scores.Add(score);
            }
        }
    }
}
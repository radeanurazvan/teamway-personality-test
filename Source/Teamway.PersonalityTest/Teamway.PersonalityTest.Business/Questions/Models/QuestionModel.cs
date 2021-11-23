using System;
using System.Collections.Generic;
using System.Linq;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    public class QuestionModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public IReadOnlyCollection<QuestionAnswerModel> Answers { get; set; }
    }

    public static class QuestionExtensions
    {
        public static QuestionModel ToModel(this Question question)
        {
            return new QuestionModel
            {
                Id = question.Id,
                Text = question.Text,
                Answers = question.Answers.Select(a => new QuestionAnswerModel
                {
                    Id = a.Id,
                    Text = a.Text
                }).ToList()
            };
        }
    }
}
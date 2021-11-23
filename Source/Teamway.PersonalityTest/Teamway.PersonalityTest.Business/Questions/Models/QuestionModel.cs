using System;
using System.Collections.Generic;

namespace Teamway.PersonalityTest.Business
{
    public class QuestionModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public IReadOnlyCollection<QuestionAnswerModel> Answers { get; set; }
    }
}
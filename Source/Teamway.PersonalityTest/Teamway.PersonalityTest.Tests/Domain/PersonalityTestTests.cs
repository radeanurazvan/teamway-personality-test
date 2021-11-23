using Xunit;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Tests.Domain
{
    public class PersonalityTestTests
    {
        private readonly Question question1 = QuestionsFactory.Any();
        private readonly Question question2 = QuestionsFactory.Any();
        private readonly Question question3 = QuestionsFactory.Any();

        [Fact]
        public void Given_GetCurrentQuestion_When_SomeQuestionsAnswered_Then_ShouldReturnFirstQuestionNotAnswered()
        {
            // Arrange
            var sut = Test.Create(new List<Question> {question1, question2, question3}).Value;
            sut.Answer(question1.Id, question1.Answers.First());

            // Act
            var currentQuestion = sut.GetCurrentQuestion();

            // Assert
            currentQuestion.HasValue.Should().BeTrue();
            currentQuestion.Value.Should().Be(question2.Id);
        }

        [Fact]
        public void Given_GetCurrentQuestion_When_AllQuestionsAnswered_Then_ShouldReturnNothing()
        {
            // Arrange
            var sut = Test.Create(new List<Question> { question1, question2, question3 }).Value;
            sut.Answer(question1.Id, question1.Answers.First());
            sut.Answer(question2.Id, question2.Answers.First());
            sut.Answer(question3.Id, question3.Answers.First());

            // Act
            var currentQuestion = sut.GetCurrentQuestion();

            // Assert
            currentQuestion.HasNoValue.Should().BeTrue();
        }
    }
}
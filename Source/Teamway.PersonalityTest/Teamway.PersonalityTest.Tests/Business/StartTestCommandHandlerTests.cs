using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using Moq;
using Teamway.PersonalityTest.Business;
using Teamway.PersonalityTest.Domain;
using Xunit;

namespace Teamway.PersonalityTest.Tests.Business
{
    public class StartTestCommandHandlerTests
    {
        private readonly Mock<IRepository<Test>> testsRepositoryMock = new Mock<IRepository<Test>>();
        private readonly Mock<IRepository<Question>> questionsRepositoryMock = new Mock<IRepository<Question>>();

        [Fact]
        public void When_NoQuestionsDefined_Then_ShouldFail()
        {
            // Arrange
            questionsRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Question>());

            // Act
            var result = Sut().Handle(new StartTestCommand(), CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            result.IsFailure.Should().BeTrue();

            testsRepositoryMock.Verify(m => m.Add(It.IsAny<Test>()), Times.Never);
            testsRepositoryMock.Verify(m => m.SaveChanges(), Times.Never);
        }

        [Fact]
        public void When_QuestionsAreDefined_Then_ShouldStart()
        {
            // Arrange
            questionsRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Question> { QuestionsFactory.Any() });

            // Act
            var result = Sut().Handle(new StartTestCommand(), CancellationToken.None).GetAwaiter().GetResult();

            // Assert
            result.IsSuccess.Should().BeTrue();

            testsRepositoryMock.Verify(m => m.Add(It.Is<Test>(t => t.Id == result.Value)), Times.Once);
            testsRepositoryMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        private StartTestCommandHandler Sut() => new(testsRepositoryMock.Object, questionsRepositoryMock.Object);
    }
}
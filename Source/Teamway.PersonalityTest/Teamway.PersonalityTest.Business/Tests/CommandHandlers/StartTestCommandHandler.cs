using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MediatR;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    internal sealed class StartTestCommandHandler : IRequestHandler<StartTestCommand, Result<Guid>>
    {
        private readonly IRepository<Test> testsRepository;
        private readonly IRepository<Question> questionsRepository;

        public StartTestCommandHandler(IRepository<Test> testsRepository, IRepository<Question> questionsRepository)
        {
            this.testsRepository = testsRepository;
            this.questionsRepository = questionsRepository;
        }

        public Task<Result<Guid>> Handle(StartTestCommand request, CancellationToken cancellationToken)
        {
            var questions = questionsRepository.GetAll();

            var result = Test.Create(questions)
                .Tap(t => testsRepository.Add(t))
                .Tap(() => testsRepository.SaveChanges())
                .Map(t => t.Id);

            return Task.FromResult(result);
        }
    }
}
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Business
{
    internal sealed class GetTestScoreQueryHandler : IRequestHandler<GetTestScoreQuery, Maybe<IEnumerable<TestScoreModel>>>
    {
        private readonly IRepository<Test> testsRepository;

        public GetTestScoreQueryHandler(IRepository<Test> testsRepository)
        {
            this.testsRepository = testsRepository;
        }

        public Task<Maybe<IEnumerable<TestScoreModel>>> Handle(GetTestScoreQuery request, CancellationToken cancellationToken)
        {
            var scores = testsRepository.GetOne(t => t.Id == request.TestId)
                .Where(t => t.IsFinished())
                .Map(t => t.Scores.Select(s => new TestScoreModel { PersonalityType = s.Type, Score = s.Score} ));

            return Task.FromResult(scores);
        }
    }
}
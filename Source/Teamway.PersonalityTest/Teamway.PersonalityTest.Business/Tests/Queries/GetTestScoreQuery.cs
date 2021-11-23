using System;
using MediatR;
using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Business
{
    public sealed class GetTestScoreQuery : IRequest<Maybe<IEnumerable<TestScoreModel>>>
    {
        public GetTestScoreQuery(Guid testId)
        {
            TestId = testId;
        }

        public Guid TestId { get; private set; }
    }
}
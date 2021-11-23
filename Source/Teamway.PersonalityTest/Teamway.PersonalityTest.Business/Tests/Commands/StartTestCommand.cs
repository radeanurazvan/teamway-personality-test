using System;
using CSharpFunctionalExtensions;
using MediatR;

namespace Teamway.PersonalityTest.Business
{
    public sealed class StartTestCommand : IRequest<Result<Guid>>
    {
    }
}
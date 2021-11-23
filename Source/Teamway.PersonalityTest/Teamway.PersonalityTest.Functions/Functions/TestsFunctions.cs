using System;
using MediatR;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Teamway.PersonalityTest.Business;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Teamway.PersonalityTest.Functions
{
    public sealed class TestsFunctions
    {
        private readonly IMediator mediator;

        public TestsFunctions(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [FunctionName(nameof(StartTest))]
        public async Task<IActionResult> StartTest([HttpTrigger(AuthorizationLevel.Function, HttpVerbs.Post, Route = "v1/tests")] HttpRequest req)
        {
            var command = new StartTestCommand();
            var result = await mediator.Send(command);

            return result.IsSuccess 
                ? new OkObjectResult(result.Value) 
                : (IActionResult) new BadRequestObjectResult(result.Error);
        }

        [FunctionName(nameof(AnswerTestQuestion))]
        public async Task<IActionResult> AnswerTestQuestion([HttpTrigger(AuthorizationLevel.Function, HttpVerbs.Post, Route = "v1/tests/{id}/answers")] HttpRequest req, Guid? id)
        {
            var result = await req.DeserializeBodyPayload<AnswerTestQuestionModel>()
                .Map(m => new AnswerTestQuestionCommand(id.GetValueOrDefault(), m.QuestionId, m.AnswerId))
                .Bind(c => mediator.Send(c));

            return result.IsSuccess
                ? new OkObjectResult(result.Value)
                : (IActionResult)new BadRequestObjectResult(result.Error);
        }
    }
}

using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Teamway.PersonalityTest.Business;

namespace Teamway.PersonalityTest.Functions
{
    public sealed class QuestionsFunctions
    {
        private readonly IMediator mediator;

        public QuestionsFunctions(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [FunctionName(nameof(GetQuestion))]
        public async Task<IActionResult> GetQuestion([HttpTrigger(AuthorizationLevel.Function, HttpVerbs.Get, Route = "v1/questions/{id}")] HttpRequest req, Guid? id)
        {
            var query = new GetQuestionQuery(id.GetValueOrDefault());
            var question = await mediator.Send(query);

            return question.HasValue 
                ? new OkObjectResult(question.Value) 
                : (IActionResult) new NotFoundResult();
        }
    }
}
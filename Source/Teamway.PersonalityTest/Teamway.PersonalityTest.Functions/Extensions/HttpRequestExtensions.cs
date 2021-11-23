using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Functions
{
    public static class HttpRequestExtensions
    {
        public static async Task<Result<T>> DeserializeBodyPayload<T>(this HttpRequest request) where T : class
        {
            using var reader = new StreamReader(request.Body);
            var body = JsonConvert.DeserializeObject<T>(await reader.ReadToEndAsync());

            return Result.SuccessIf(body != null, body, "BAD_REQUEST");
        }
    }
}
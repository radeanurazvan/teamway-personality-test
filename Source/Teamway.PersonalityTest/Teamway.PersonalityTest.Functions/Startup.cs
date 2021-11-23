using Teamway.PersonalityTest.Business;
using Teamway.PersonalityTest.Functions;
using Teamway.PersonalityTest.Persistence;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Teamway.PersonalityTest.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services
                .AddTeamwayPersistence()
                .AddTeamwayBusiness();
        }
    }
}
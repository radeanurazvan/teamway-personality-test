using Microsoft.Extensions.DependencyInjection;
using Teamway.PersonalityTest.Domain;

namespace Teamway.PersonalityTest.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTeamwayPersistence(this IServiceCollection services)
        {
            return services
                .AddSingleton(typeof(IRepository<>), typeof(InMemoryRepository<>))
                .AddSingleton<IRepository<Question>, InMemoryQuestionsRepository>();
        }
    }
}
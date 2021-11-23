using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Teamway.PersonalityTest.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTeamwayBusiness(this IServiceCollection services)
        {
            return services.AddMediatR(BusinessAssembly.Value);
        }
    }
}
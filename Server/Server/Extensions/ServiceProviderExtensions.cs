using Database.Repositories;
using Shared.Interfaces;

namespace Server.Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPumpsRepository, PumpsRepository>();
        }
    }
}

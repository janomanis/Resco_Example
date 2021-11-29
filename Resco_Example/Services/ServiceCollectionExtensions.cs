using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Resco_Example.Models;

namespace Resco_Example.Services
{
    /// <summary>
    /// Extensions for adding services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.TryAddTransient<IPlayerRepository, PlayerRepository>();
            services.TryAddTransient<ISingleWalletRepository, PlayersWalletRepository>();

            return services;
        }
    }
}

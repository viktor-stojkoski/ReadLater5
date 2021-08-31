namespace ReadLater5.Registers
{
    using Contracts.Settings;

    using Microsoft.Extensions.DependencyInjection;

    using ReadLater5.Settings;

    public static partial class Register
    {
        public static IServiceCollection RegisterSettings(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringSettings, ConnectionStringSettings>();

            return services;
        }
    }
}

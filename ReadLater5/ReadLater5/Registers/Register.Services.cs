namespace ReadLater5.Registers
{
    using Contracts.Auth;

    using Microsoft.Extensions.DependencyInjection;

    using Services.Auth;

    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}

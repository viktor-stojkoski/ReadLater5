namespace ReadLater5.Registers
{
    using System.Security.Claims;

    using Contracts.Auth;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    using Shared.User.Interfaces;

    public static partial class Register
    {
        public static IServiceCollection RegisterCurrentUser(this IServiceCollection services)
        {
            services.AddScoped(provider =>
            {
                IHttpContextAccessor httpContextAccessor =
                    provider.GetService<IHttpContextAccessor>();

                IAuthService authService = provider.GetService<IAuthService>();

                ICurrentUser currentUser = null;

                ClaimsIdentity claimsIdentity =
                    httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;

                bool isAuthenticated = claimsIdentity?.IsAuthenticated ?? false;

                if (isAuthenticated)
                {
                    currentUser = authService.GetCurrentUserFromClaims(claimsIdentity);
                }

                return currentUser;
            });

            return services;
        }
    }
}

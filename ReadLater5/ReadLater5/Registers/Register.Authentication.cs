namespace ReadLater5.Registers
{
    using System;
    using System.Text;

    using Contracts.Settings;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using ReadLater5.Settings;

    using Storage.Infrastructure.Context;
    using Storage.User.Entities;

    public static partial class Register
    {
        public static IServiceCollection RegisterAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IAuthSettings authSettings = new AuthSettings(configuration);

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ReadLaterDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireSignedTokens = true,
                        RequireExpirationTime = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}

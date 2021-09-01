namespace ReadLater5.Registers
{
    using System;

    using Shared.Infrastructure;
    using Shared.Settings;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Queries.Infrastructure.Context;

    using ReadLater5.Settings;

    using Storage;
    using Storage.Infrastructure.Context;
    using Storage.Infrastructure.UnitOfWork;

    public static partial class Register
    {
        public static IServiceCollection RegisterDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            IConnectionStringSettings connectionStringSettings =
                new ConnectionStringSettings(configuration);

            services.AddScoped<IReadLaterDbContext, ReadLaterDbContext>();
            services.AddScoped<IReadLaterReadonlyDbContext, ReadLaterReadonlyDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ReadLaterDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: connectionStringSettings.SqlConnectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                    });
            });

            services.AddDbContext<ReadLaterReadonlyDbContext>(options =>
            {
                options.UseSqlServer(
                    connectionString: connectionStringSettings.SqlConnectionReadonlyString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null);
                    });
            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}

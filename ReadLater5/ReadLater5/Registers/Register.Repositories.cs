namespace ReadLater5.Registers
{
    using Shared.Category.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    using Storage.Category.Repositories;

    public static partial class Register
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}

namespace ReadLater5.Registers
{
    using Contracts.Bookmark.Repositories;
    using Contracts.Category.Repositories;
    using Contracts.User.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    using Storage.Bookmark.Repositories;
    using Storage.Category.Repositories;
    using Storage.User.Repositories;

    public static partial class Register
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            return services;
        }
    }
}

namespace ReadLater5.Registers
{
    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using Queries;

    using Services;

    using Shared.Mediator;

    public static partial class Register
    {
        public static IServiceCollection RegisterMediatr(this IServiceCollection services)
        {
            services.AddScoped<IReadLaterPublisher, ReadLaterPublisher>();
            services.AddScoped<ReadLaterMediator, ReadLaterMediator>();

            services.AddMediatR(
                typeof(CommandsAssemblyMarker).Assembly,
                typeof(QueriesAssemblyMarker).Assembly);

            return services;
        }
    }
}

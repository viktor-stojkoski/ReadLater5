namespace Services.User
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.User.Repositories;

    using Entity.User;

    using MediatR;

    using Shared.ErrorCodes;
    using Shared.Exceptions;
    using Shared.Mediator;

    /// <summary>
    /// Logins user.
    /// </summary>
    public record LoginUserCommand(string Email, string Password) : ICommand<Unit>;

    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, Unit>
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public LoginUserCommandHandler(IApplicationUserRepository applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user =
                await _applicationUserRepository.GetUserByEmailAsync(request.Email);

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                throw new ReadLaterNotFoundException(ErrorCodes.UserNoPasswordSet);
            }

            return Unit.Value;
        }
    }
}

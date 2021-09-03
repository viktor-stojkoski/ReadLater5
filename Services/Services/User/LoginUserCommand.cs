namespace Services.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Auth;
    using Contracts.Infrastructure;
    using Contracts.User.Responses;

    using Microsoft.AspNetCore.Identity;

    using Shared.ErrorCodes;
    using Shared.Exceptions;
    using Shared.Mediator;
    using Shared.Utils;

    /// <summary>
    /// Logins user.
    /// </summary>
    public record LoginUserCommand(string Email, string Password) : ICommand<LoggedInUserDto>;

    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoggedInUserDto>
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<Storage.User.Entities.ApplicationUser> _signInManager;
        private readonly UserManager<Storage.User.Entities.ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(
            //IApplicationUserRepository applicationUserRepository,
            IUnitOfWork unitOfWork,
            SignInManager<Storage.User.Entities.ApplicationUser> signInManager,
            UserManager<Storage.User.Entities.ApplicationUser> userManager,
            IAuthService authService)
        {
            //_applicationUserRepository = applicationUserRepository;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<LoggedInUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            Storage.User.Entities.ApplicationUser user =
                await _userManager.FindByEmailAsync(request.Email);

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                throw new ReadLaterNotFoundException(ErrorCodes.UserNoPasswordSet);
            }

            SignInResult signInResult =
                await _signInManager.CheckPasswordSignInAsync(
                    user: user,
                    password: request.Password,
                    lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                throw new ReadLaterValidationException(ErrorCodes.UserPasswordDoesNotMatch);
            }

            string token = StringHelper.GenerateSha256Hash(Guid.NewGuid().ToString());
            DateTime expiresOn = DateTime.UtcNow.AddDays(1);

            user.SetRefreshToken(
                refreshToken: token,
                refreshTokenExpiresOn: expiresOn);

            await _userManager.UpdateAsync(user);

            //_applicationUserRepository.Update(user);

            await _unitOfWork.SaveAsync();

            return new LoggedInUserDto
            {
                Token = _authService.GenerateJwtToken(
                    id: user.Id,
                    email: user.Email,
                    username: user.UserName,
                    expiresOn: expiresOn)
            };
        }
    }
}

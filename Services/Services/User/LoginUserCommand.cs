namespace Services.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

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

        public LoginUserCommandHandler(
            //IApplicationUserRepository applicationUserRepository,
            IUnitOfWork unitOfWork,
            SignInManager<Storage.User.Entities.ApplicationUser> signInManager,
            UserManager<Storage.User.Entities.ApplicationUser> userManager)
        {
            //_applicationUserRepository = applicationUserRepository;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _userManager = userManager;
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

            user.SetRefreshToken(
                refreshToken: token,
                DateTime.UtcNow.AddDays(1));

            await _userManager.UpdateAsync(user);

            //_applicationUserRepository.Update(user);

            await _unitOfWork.SaveAsync();

            return new LoggedInUserDto
            {
                Token = token
            };
        }
    }
}

namespace ReadLater5.Controllers.Api
{
    using System.Threading.Tasks;

    using Contracts.User.Requests;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.User;

    using Shared.Mediator;

    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IReadLaterPublisher _readLaterPublisher;

        public AuthController(IReadLaterPublisher readLaterPublisher)
        {
            _readLaterPublisher = readLaterPublisher;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(ApplicationUserLoginRequest request)
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                new LoginUserCommand(request.Email, request.Password)));
        }
    }
}

namespace Contracts.Auth
{
    using System.Security.Claims;

    using Shared.User.Interfaces;

    public interface IAuthService
    {
        /// <summary>
        /// Returns the current user from claims.
        /// </summary>
        ICurrentUser GetCurrentUserFromClaims(ClaimsIdentity claims);
    }
}

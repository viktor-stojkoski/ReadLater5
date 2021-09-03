namespace Contracts.Auth
{
    using System;
    using System.Security.Claims;

    using Shared.User.Interfaces;

    public interface IAuthService
    {
        /// <summary>
        /// Returns the current user from claims.
        /// </summary>
        ICurrentUser GetCurrentUserFromClaims(ClaimsIdentity claims);

        /// <summary>
        /// Generates JWT token for authenticating.
        /// </summary>
        string GenerateJwtToken(string id, string email, string username, DateTime expiresOn);
    }
}

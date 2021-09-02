namespace Services.Auth
{
    using System.Security.Claims;

    using Contracts.Auth;

    using Shared.User;
    using Shared.User.Interfaces;

    public class AuthService : IAuthService
    {
        public ICurrentUser GetCurrentUserFromClaims(ClaimsIdentity claims)
        {
            return new CurrentUser(
                id: GetFromClaims(claims, ClaimTypes.NameIdentifier),
                name: GetFromClaims(claims, ClaimTypes.Name),
                email: GetFromClaims(claims, ClaimTypes.Email));
        }

        private static string GetFromClaims(ClaimsIdentity claimsIdentity, string claimType)
        {
            return claimsIdentity.FindFirst(claimType)?.Value ?? default;
        }
    }
}

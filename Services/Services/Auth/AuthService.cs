namespace Services.Auth
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using Contracts.Auth;
    using Contracts.Settings;

    using Microsoft.IdentityModel.Tokens;

    using Shared.User;
    using Shared.User.Interfaces;

    public class AuthService : IAuthService
    {
        private readonly IAuthSettings _authSettings;

        public AuthService(IAuthSettings authSettings)
        {
            _authSettings = authSettings;
        }

        public ICurrentUser GetCurrentUserFromClaims(ClaimsIdentity claims)
        {
            return new CurrentUser(
                id: GetFromClaims(claims, ClaimTypes.NameIdentifier),
                name: GetFromClaims(claims, ClaimTypes.Name),
                email: GetFromClaims(claims, ClaimTypes.Email));
        }

        public string GenerateJwtToken(string id, string email, string username, DateTime expiresOn)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.UTF8.GetBytes(_authSettings.JwtKey);
            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, id.ToString()) }),
                Expires = expiresOn,
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token =
                tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static string GetFromClaims(ClaimsIdentity claimsIdentity, string claimType)
        {
            return claimsIdentity.FindFirst(claimType)?.Value ?? default;
        }
    }
}

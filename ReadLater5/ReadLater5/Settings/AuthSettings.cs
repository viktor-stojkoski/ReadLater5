namespace ReadLater5.Settings
{
    using Contracts.Settings;

    using Microsoft.Extensions.Configuration;

    public class AuthSettings : IAuthSettings
    {
        private readonly IConfiguration _configuration;

        public AuthSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string JwtKey => _configuration.GetValue<string>("auth:jwtKey");
    }
}

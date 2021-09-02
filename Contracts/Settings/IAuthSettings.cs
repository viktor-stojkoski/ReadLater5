namespace Contracts.Settings
{
    public interface IAuthSettings
    {
        /// <summary>
        /// JWT key for authentication.
        /// </summary>
        string JwtKey { get; }
    }
}

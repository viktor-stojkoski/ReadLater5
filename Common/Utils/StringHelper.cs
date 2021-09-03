namespace Shared.Utils
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringHelper
    {
        /// <summary>
        /// Generates hash for given string.
        /// </summary>
        public static string GenerateSha256Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            SHA256 hash = SHA256.Create();

            return Convert.ToBase64String(
                hash.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}

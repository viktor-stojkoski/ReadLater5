namespace Entity.User
{
    using System;

    using Entity.Common.Entities;
    using Entity.User.ValueObjects;

    public class ApplicationUser : Entity
    {
        private ApplicationUser() { }

        /// <summary>
        /// User's id.
        /// </summary>
        public new string Id { get; private set; }

        /// <summary>
        /// User's user name.
        /// </summary>
        public UserNameValue UserName { get; private set; }

        /// <summary>
        /// User's email address.
        /// </summary>
        public EmailValue Email { get; private set; }

        /// <summary>
        /// User's password hash.
        /// </summary>
        public string PasswordHash { get; private set; }

        public string NormalizedUserName { get; private set; }

        public string NormalizedEmail { get; private set; }

        public bool EmailConfirmed { get; private set; }

        public string SecurityStamp { get; private set; }

        public string PhoneNumber { get; private set; }

        public bool PhoneNumberConfirmed { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public DateTimeOffset? LockoutEnd { get; private set; }

        public bool LockoutEnabled { get; private set; }

        public int AccessFailedCount { get; private set; }

        public string Discriminator { get; private set; }

        /// <summary>
        /// User's refresh access token.
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// User's refresh access token expiring date.
        /// </summary>
        public DateTime? RefreshTokenExpiresOn { get; private set; }

        /// <summary>
        /// Only for mapping DB to Domain.
        /// </summary>
        public ApplicationUser(
            string id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userName,
            string email,
            string passwordHash,
            string refreshToken,
            DateTime? refreshTokenExpiresOn,
            string normalizedUserName,
            string normalizedEmail,
            bool emailConfirmed,
            string securityStamp,
            string phoneNumber,
            bool phoneNumberConfirmed,
            bool twoFactorEnabled,
            DateTimeOffset? lockoutEnd,
            bool lockoutEnabled,
            int accessFailedCount,
            string discriminator)
        {
            UserNameValue userNameValue = new(userName);
            EmailValue emailValue = new(email);

            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserName = userNameValue;
            Email = emailValue;

            PasswordHash = passwordHash;
            RefreshToken = refreshToken;
            RefreshTokenExpiresOn = refreshTokenExpiresOn;
            NormalizedUserName = normalizedUserName;
            NormalizedEmail = normalizedEmail;
            EmailConfirmed = emailConfirmed;
            SecurityStamp = securityStamp;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            TwoFactorEnabled = twoFactorEnabled;
            LockoutEnd = lockoutEnd;
            LockoutEnabled = lockoutEnabled;
            AccessFailedCount = accessFailedCount;
            Discriminator = discriminator;
        }

        public void SetRefreshToken(string refreshToken, DateTime refreshTokenExpiresOn)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiresOn = refreshTokenExpiresOn;
        }
    }
}

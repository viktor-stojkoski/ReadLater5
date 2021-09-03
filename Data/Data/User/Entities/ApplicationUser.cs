namespace Storage.User.Entities
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Storage.Bookmark.Entities;
    using Storage.Category.Entities;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public Guid Uid { get; protected internal set; }

        public DateTime CreatedOn { get; protected internal set; }

        public DateTime? DeletedOn { get; protected internal set; }

        public string RefreshToken { get; protected internal set; }

        public DateTime? RefreshTokenExpiresOn { get; protected internal set; }

        public string Discriminator { get; protected internal set; }

        public virtual ICollection<Category> Categories { get; protected internal set; }

        public virtual ICollection<Bookmark> Bookmarks { get; protected internal set; }

        public ApplicationUser(
            string id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userName,
            string passwordHash,
            string email,
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
            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
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

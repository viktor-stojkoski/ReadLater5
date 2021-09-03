namespace Storage.User.Mappers
{
    using Entity.User;

    internal static class ApplicationUserMapper
    {
        internal static ApplicationUser ToApplicationUserDomain(this Entities.ApplicationUser dbUser) =>
            new(id: dbUser.Id,
                uid: dbUser.Uid,
                createdOn: dbUser.CreatedOn,
                deletedOn: dbUser.DeletedOn,
                userName: dbUser.UserName,
                email: dbUser.Email,
                passwordHash: dbUser.PasswordHash,
                refreshToken: dbUser.RefreshToken,
                refreshTokenExpiresOn: dbUser.RefreshTokenExpiresOn,
                normalizedUserName: dbUser.NormalizedUserName,
                normalizedEmail: dbUser.NormalizedEmail,
                emailConfirmed: dbUser.EmailConfirmed,
                securityStamp: dbUser.SecurityStamp,
                phoneNumber: dbUser.PhoneNumber,
                phoneNumberConfirmed: dbUser.PhoneNumberConfirmed,
                twoFactorEnabled: dbUser.TwoFactorEnabled,
                lockoutEnabled: dbUser.LockoutEnabled,
                lockoutEnd: dbUser.LockoutEnd,
                accessFailedCount: dbUser.AccessFailedCount,
                discriminator: dbUser.Discriminator);

        internal static Entities.ApplicationUser ToApplicationUserDb(this ApplicationUser domainUser) =>
            new(id: domainUser.Id,
                uid: domainUser.Uid,
                createdOn: domainUser.CreatedOn,
                deletedOn: domainUser.DeletedOn,
                userName: domainUser.UserName,
                email: domainUser.Email,
                passwordHash: domainUser.PasswordHash,
                refreshToken: domainUser.RefreshToken,
                refreshTokenExpiresOn: domainUser.RefreshTokenExpiresOn,
                normalizedUserName: domainUser.NormalizedUserName,
                normalizedEmail: domainUser.NormalizedEmail,
                emailConfirmed: domainUser.EmailConfirmed,
                securityStamp: domainUser.SecurityStamp,
                phoneNumber: domainUser.PhoneNumber,
                phoneNumberConfirmed: domainUser.PhoneNumberConfirmed,
                twoFactorEnabled: domainUser.TwoFactorEnabled,
                lockoutEnabled: domainUser.LockoutEnabled,
                lockoutEnd: domainUser.LockoutEnd,
                accessFailedCount: domainUser.AccessFailedCount,
                discriminator: domainUser.Discriminator);
    }
}

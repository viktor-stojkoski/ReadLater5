namespace Services.User
{
    using Storage.User.Entities;

    internal static class ApplicationUserMapper
    {
        internal static ApplicationUser ToApplicationUserDb(this Entity.User.ApplicationUser domainUser) =>
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

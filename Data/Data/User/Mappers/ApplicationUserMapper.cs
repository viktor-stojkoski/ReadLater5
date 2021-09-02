namespace Storage.User.Mappers
{
    using Entity.User;

    internal static class ApplicationUserMapper
    {
        internal static ApplicationUser ToApplicationUserDomain(this Entities.ApplicationUser user) =>
            new(id: user.Id,
                uid: user.Uid,
                createdOn: user.CreatedOn,
                deletedOn: user.DeletedOn,
                userName: user.UserName,
                email: user.Email,
                passwordHash: user.PasswordHash);
    }
}

namespace Contracts.User.Repositories
{
    using System.Threading.Tasks;

    using Entity.User;

    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Returns the user by email.
        /// </summary>
        Task<ApplicationUser> GetUserByEmailAsync(string email);
    }
}

namespace Storage.User.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts.User.Repositories;

    using Entity.User;

    using Microsoft.EntityFrameworkCore;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    using Storage.Infrastructure.Context;

    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IReadLaterDbContext _dbContext;

        public ApplicationUserRepository(IReadLaterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            ApplicationUser applicationUser =
                await _dbContext.Set<ApplicationUser>()
                    .Where(x => x.DeletedOn == null).AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Email == email);

            if (applicationUser is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.UserNotFound);
            }

            return applicationUser;
        }
    }
}

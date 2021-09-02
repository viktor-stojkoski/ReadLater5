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
    using Storage.User.Mappers;

    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly IReadLaterDbContext _dbContext;

        public ApplicationUserRepository(IReadLaterDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            Entities.ApplicationUser applicationUser =
                await _dbContext.Set<Entities.ApplicationUser>()
                    .Where(x => x.DeletedOn == null).AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Email == email);

            if (applicationUser is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.UserNotFound);
            }

            return applicationUser.ToApplicationUserDomain();
        }
    }
}

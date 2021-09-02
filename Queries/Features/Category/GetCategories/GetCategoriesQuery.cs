namespace Queries.Features.Category.GetCategories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Queries.Entities;
    using Queries.Infrastructure.Context;

    using Shared.Mediator;
    using Shared.User.Interfaces;

    /// <summary>
    /// Returns all categories.
    /// </summary>
    public record GetCategoriesQuery() : IQuery<IReadOnlyList<CategoryDto>> { }

    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IReadOnlyList<CategoryDto>>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;
        private readonly ICurrentUser _currentUser;

        public GetCategoriesQueryHandler(
            IReadLaterReadonlyDbContext dbContext,
            ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }

        public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AllNoTrackedOf<Category>()
                .Where(category => category.UserId == _currentUser.Id)
                .Select(category => new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToListAsync();
        }
    }
}

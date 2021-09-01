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

    /// <summary>
    /// Returns all categories.
    /// </summary>
    public record GetCategoriesQuery() : IQuery<IReadOnlyList<CategoryDto>> { }

    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IReadOnlyList<CategoryDto>>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetCategoriesQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AllNoTrackedOf<Category>()
                .Select(category => new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).ToListAsync();
        }
    }
}

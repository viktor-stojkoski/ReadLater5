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

    public record GetCategoriesQuery() : IQuery<Category> { }

    public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, Category>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetCategoriesQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Category> dbCategory =
                await _dbContext.SetOf<Category>()
                    .ToListAsync();

            return dbCategory.First();
        }
    }
}

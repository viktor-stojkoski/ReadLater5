namespace Queries.Features.Category.GetCategory
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Exceptions;

    using Microsoft.EntityFrameworkCore;

    using Queries.Entities;
    using Queries.Infrastructure.Context;

    using Shared.ErrorCodes;
    using Shared.Mediator;

    /// <summary>
    /// Returns category by id.
    /// </summary>
    public record GetCategoryQuery(int Id) : IQuery<CategoryDto>;

    public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetCategoryQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            CategoryDto category = await _dbContext.AllNoTrackedOf<Category>()
                .Where(category => category.Id == request.Id)
                .Select(category => new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                }).SingleOrDefaultAsync();

            if (category is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.CategoryNotFound);
            }

            return category;
        }
    }
}

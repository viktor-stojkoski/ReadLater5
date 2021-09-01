namespace Queries.Features.Category.GetCategoryByName
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Queries.Entities;
    using Queries.Infrastructure.Context;

    using Shared.ErrorCodes;
    using Shared.Exceptions;
    using Shared.Mediator;

    /// <summary>
    /// Returns category by name.
    /// </summary>
    public record GetCategoryByNameQuery(string Name) : IQuery<CategoryDto>;

    public class GetCategoryByNameQueryHandler : IQueryHandler<GetCategoryByNameQuery, CategoryDto>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetCategoryByNameQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CategoryDto> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            CategoryDto category = await _dbContext.AllNoTrackedOf<Category>()
                .Where(category => category.Name.ToUpper() == request.Name.ToUpper())
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

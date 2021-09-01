namespace Storage.Category.Repositories
{
    using System.Threading.Tasks;

    using Shared.Category.Repositories;
    using Shared.Exceptions;

    using Entity.Category;

    using Microsoft.EntityFrameworkCore;

    using Shared.ErrorCodes;

    using Storage.Category.Mappers;
    using Storage.Common.Repositories;
    using Storage.Infrastructure.Context;

    public class CategoryRepository : Repository<Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(IReadLaterDbContext readLaterDbContext)
            : base(readLaterDbContext) { }

        public async Task<Category> GetCategoryAsync(int id)
        {
            Entities.Category dbCategory = await AllNoTrackedOf()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (dbCategory is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.CategoryNotFound);
            }

            return dbCategory.ToCategoryDomain();
        }

        public async Task<bool> DoesCategoryExists(string name)
        {
            return await AllNoTrackedOf()
                .AnyAsync(x => x.Name.ToUpper() == name.ToUpper());
        }

        public void Insert(Category category)
        {
            Insert(category.ToCategoryDb());
        }

        public void Update(Category category)
        {
            Update(category.ToCategoryDb());
        }
    }
}

namespace Contracts.Category.Repositories
{
    using System.Threading.Tasks;

    using Entity.Category;

    public interface ICategoryRepository
    {
        /// <summary>
        /// Returns category by id.
        /// </summary>
        Task<Category> GetCategoryAsync(string userId, int id);

        /// <summary>
        /// Returns boolean indicating if category with given name already exists.
        /// </summary>
        Task<bool> DoesCategoryExists(string userId, string name);

        /// <summary>
        /// Inserts new category.
        /// </summary>
        void Insert(Category category);

        /// <summary>
        /// Updates category.
        /// </summary>
        void Update(Category category);
    }
}

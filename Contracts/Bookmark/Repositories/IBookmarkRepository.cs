namespace Contracts.Bookmark.Repositories
{
    using System.Threading.Tasks;

    using Entity.Bookmark;

    public interface IBookmarkRepository
    {
        /// <summary>
        /// Returns bookmark by id.
        /// </summary>
        Task<Bookmark> GetBookmarkAsync(string userId, int id);

        /// <summary>
        /// Inserts new bookmark.
        /// </summary>
        void Insert(Bookmark bookmark);

        /// <summary>
        /// Updates bookmark.
        /// </summary>
        void Update(Bookmark bookmark);
    }
}

namespace Storage.Bookmark.Repositories
{
    using System.Threading.Tasks;

    using Contracts.Bookmark.Repositories;

    using Entity.Bookmark;

    using Microsoft.EntityFrameworkCore;

    using Shared.ErrorCodes;
    using Shared.Exceptions;

    using Storage.Bookmark.Mappers;
    using Storage.Common.Repositories;
    using Storage.Infrastructure.Context;

    public class BookmarkRepository : Repository<Entities.Bookmark>, IBookmarkRepository
    {
        public BookmarkRepository(IReadLaterDbContext readLaterDbContext)
            : base(readLaterDbContext) { }

        public async Task<Bookmark> GetBookmarkAsync(int id)
        {
            Entities.Bookmark dbBookmark = await AllNoTrackedOf()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (dbBookmark is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.BookmarkNotFound);
            }

            return dbBookmark.ToBookmarkDomain();
        }

        public void Insert(Bookmark bookmark)
        {
            Insert(bookmark.ToBookmarkDb());
        }

        public void Update(Bookmark bookmark)
        {
            Update(bookmark.ToBookmarkDb());
        }
    }
}

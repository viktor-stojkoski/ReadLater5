namespace Queries.Features.Bookmark.GetBookmark
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
    /// Returns bookmark with the given id.
    /// </summary>
    public record GetBookmarkQuery(int Id) : IQuery<BookmarkDto>;

    public class GetBookmarkQueryHandler : IQueryHandler<GetBookmarkQuery, BookmarkDto>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetBookmarkQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookmarkDto> Handle(GetBookmarkQuery request, CancellationToken cancellationToken)
        {
            BookmarkDto bookmark = await _dbContext.AllNoTrackedOf<Bookmark>()
                .Where(bookmark => bookmark.Id == request.Id)
                .Include(bookmark => bookmark.Category)
                .Select(bookmark => new BookmarkDto
                {
                    Id = bookmark.Id,
                    Url = bookmark.Url,
                    ShortDescription = bookmark.ShortDescription,
                    Category = new BookmarkCategoryDto
                    {
                        Name = bookmark.Category.Name
                    }
                }).SingleOrDefaultAsync();

            if (bookmark is null)
            {
                throw new ReadLaterNotFoundException(ErrorCodes.BookmarkNotFound);
            }

            return bookmark;
        }
    }
}

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
    using Shared.User.Interfaces;

    /// <summary>
    /// Returns bookmark with the given id.
    /// </summary>
    public record GetBookmarkQuery(int Id) : IQuery<BookmarkDto>;

    public class GetBookmarkQueryHandler : IQueryHandler<GetBookmarkQuery, BookmarkDto>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;
        private readonly ICurrentUser _currentUser;

        public GetBookmarkQueryHandler(
            IReadLaterReadonlyDbContext dbContext,
            ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }

        public async Task<BookmarkDto> Handle(GetBookmarkQuery request, CancellationToken cancellationToken)
        {
            BookmarkDto bookmark = await _dbContext.AllNoTrackedOf<Bookmark>()
                .Where(bookmark => bookmark.UserId == _currentUser.Id
                    && bookmark.Id == request.Id)
                .Include(bookmark => bookmark.Category)
                .Select(bookmark => new BookmarkDto
                {
                    Id = bookmark.Id,
                    Url = bookmark.Url,
                    ShortDescription = bookmark.ShortDescription,
                    Category = new BookmarkCategoryDto
                    {
                        Id = bookmark.Category.Id,
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

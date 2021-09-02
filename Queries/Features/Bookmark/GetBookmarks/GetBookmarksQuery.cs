namespace Queries.Features.Bookmark.GetBookmarks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Queries.Entities;
    using Queries.Infrastructure.Context;

    using Shared.Mediator;
    using Shared.User.Interfaces;

    /// <summary>
    /// Returns all bookmarks.
    /// </summary>
    public record GetBookmarksQuery() : IQuery<IReadOnlyList<BookmarkDto>> { }

    public class GetBookmarksQueryHandler : IQueryHandler<GetBookmarksQuery, IReadOnlyList<BookmarkDto>>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;
        private readonly ICurrentUser _currentUser;

        public GetBookmarksQueryHandler(
            IReadLaterReadonlyDbContext dbContext,
            ICurrentUser currentUser)
        {
            _dbContext = dbContext;
            _currentUser = currentUser;
        }

        public async Task<IReadOnlyList<BookmarkDto>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AllNoTrackedOf<Bookmark>()
                .Where(bookmark => bookmark.UserId == _currentUser.Id)
                .Select(bookmark => new BookmarkDto
                {
                    Id = bookmark.Id,
                    Url = bookmark.Url,
                    ShortDescription = bookmark.ShortDescription,
                    CategoryId = bookmark.CategoryId
                }).ToListAsync();
        }
    }
}

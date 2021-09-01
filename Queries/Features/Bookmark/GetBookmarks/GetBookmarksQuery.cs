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

    /// <summary>
    /// Returns all bookmarks.
    /// </summary>
    public record GetBookmarksQuery() : IQuery<IReadOnlyList<BookmarkDto>> { }

    public class GetBookmarksQueryHandler : IQueryHandler<GetBookmarksQuery, IReadOnlyList<BookmarkDto>>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetBookmarksQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<BookmarkDto>> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.AllNoTrackedOf<Bookmark>()
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

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
    public record GetBookmarksQuery() : IQuery<Bookmark> { }

    public class GetBookmarksQueryHandler : IQueryHandler<GetBookmarksQuery, Bookmark>
    {
        private readonly IReadLaterReadonlyDbContext _dbContext;

        public GetBookmarksQueryHandler(IReadLaterReadonlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bookmark> Handle(GetBookmarksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Bookmark> dbBookmarks =
                await _dbContext.SetOf<Bookmark>()
                    .ToListAsync();

            return dbBookmarks.First();
        }
    }
}

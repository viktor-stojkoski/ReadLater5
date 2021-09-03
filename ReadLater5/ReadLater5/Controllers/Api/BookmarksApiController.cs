namespace ReadLater5.Controllers.Api
{
    using System.Threading.Tasks;

    using Contracts.Bookmark.Requests;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Queries.Features.Bookmark.GetBookmark;
    using Queries.Features.Bookmark.GetBookmarks;

    using Services.Bookmark;

    using Shared.Mediator;

    [Route("api/bookmarks")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookmarksApiController : ControllerBase
    {
        private readonly IReadLaterPublisher _readLaterPublisher;

        public BookmarksApiController(IReadLaterPublisher readLaterPublisher)
        {
            _readLaterPublisher = readLaterPublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookmarksAsync()
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarksQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookmarkAsync([FromRoute] int id)
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarkQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookmarkAsync([FromBody] CreateBookmarkRequest request)
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                    new CreateBookmarkCommand(
                        Url: request.Url,
                        ShortDescription: request.ShortDescription,
                        CategoryId: request.CategoryId)));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookmarkAsync([FromBody] UpdateBookmarkRequest request)
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                    new UpdateBookmarkCommand(
                        Id: request.Id,
                        Url: request.Url,
                        ShortDescription: request.ShortDescription,
                        CategoryId: request.CategoryId)));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> UpdateBookmarkAsync([FromRoute] int id)
        {
            return Ok(
                await _readLaterPublisher.ExecuteAsync(
                    new DeleteBookmarkCommand(id)));
        }
    }
}

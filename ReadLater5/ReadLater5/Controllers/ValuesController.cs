﻿namespace ReadLater5.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Queries.Entities;
    using Queries.Features.Bookmark.GetBookmarks;
    using Queries.Features.Category.GetCategories;

    using Shared.Mediator;

    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IReadLaterPublisher _readLaterPublisher;

        public ValuesController(IReadLaterPublisher readLaterPublisher)
        {
            _readLaterPublisher = readLaterPublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            Category category =
                await _readLaterPublisher.ExecuteAsync(new GetCategoriesQuery());

            return Ok(category);
        }

        [HttpGet("bookmarks")]
        public async Task<IActionResult> GetBookmarks()
        {
            Bookmark bookmark =
                await _readLaterPublisher.ExecuteAsync(new GetBookmarksQuery());

            return Ok(bookmark);
        }
    }
}

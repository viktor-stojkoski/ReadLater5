namespace ReadLater5.Controllers
{
    using System.Threading.Tasks;

    using Contracts.Bookmark.Requests;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Queries.Features.Bookmark.GetBookmark;
    using Queries.Features.Bookmark.GetBookmarks;
    using Queries.Features.Category.GetCategories;

    using Services.Bookmark;

    using Shared.Mediator;

    [Authorize]
    public class BookmarksController : Controller
    {
        private readonly IReadLaterPublisher _readLaterPublisher;

        public BookmarksController(IReadLaterPublisher readLaterPublisher)
        {
            _readLaterPublisher = readLaterPublisher;
        }

        public async Task<IActionResult> Index()
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarksQuery()));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarkQuery(id)));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories =
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoriesQuery());

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookmarkRequest request)
        {
            await _readLaterPublisher.ExecuteAsync(
                new CreateBookmarkCommand(
                    CategoryId: request.CategoryId,
                    ShortDescription: request.ShortDescription,
                    Url: request.Url));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories =
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoriesQuery());

            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarkQuery(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateBookmarkRequest request)
        {
            await _readLaterPublisher.ExecuteAsync(
                new UpdateBookmarkCommand(
                    Id: request.Id,
                    Url: request.Url,
                    ShortDescription: request.ShortDescription,
                    CategoryId: request.CategoryId));

            return RedirectToAction("Details", new { request.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetBookmarkQuery(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _readLaterPublisher.ExecuteAsync(
                new DeleteBookmarkCommand(id));

            return RedirectToAction("Index");
        }
    }
}

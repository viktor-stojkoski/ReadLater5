namespace ReadLater5.Controllers
{
    using System.Threading.Tasks;

    using Contracts.Category.Requests;

    using Microsoft.AspNetCore.Mvc;

    using Queries.Features.Category.GetCategories;
    using Queries.Features.Category.GetCategory;

    using Services.Category;

    using Shared.Mediator;

    public class CategoriesController : Controller
    {
        private readonly IReadLaterPublisher _readLaterPublisher;

        public CategoriesController(IReadLaterPublisher readLaterPublisher)
        {
            _readLaterPublisher = readLaterPublisher;
        }

        public async Task<IActionResult> Index()
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoriesQuery()));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoryQuery(id)));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            await _readLaterPublisher.ExecuteAsync(
                new CreateCategoryCommand(request.Name));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoryQuery(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryRequest request)
        {
            await _readLaterPublisher.ExecuteAsync(
                new UpdateCategoryCommand(
                    Id: request.Id,
                    Name: request.Name));

            return RedirectToAction("Details", new { request.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(
                await _readLaterPublisher.ExecuteAsync(
                    new GetCategoryQuery(id)));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _readLaterPublisher.ExecuteAsync(
                new DeleteCategoryCommand(Id: id));

            return RedirectToAction("Index");
        }
    }
}

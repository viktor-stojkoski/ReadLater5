namespace Services.Bookmark
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Bookmark.Repositories;
    using Contracts.Category.Repositories;
    using Contracts.Infrastructure;

    using Entity.Bookmark;
    using Entity.Category;

    using MediatR;

    using Shared.Mediator;

    /// <summary>
    /// Updates bookmark with the given id.
    /// </summary>
    public record UpdateBookmarkCommand(
        string UserId,
        int Id,
        string Url,
        string ShortDescription,
        int CategoryId) : ICommand<Unit>;

    public class UpdateBookmarkCommandHandler : ICommandHandler<UpdateBookmarkCommand, Unit>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookmarkCommandHandler(
            IBookmarkRepository bookmarkRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _bookmarkRepository = bookmarkRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
        {
            Bookmark bookmark =
                await _bookmarkRepository.GetBookmarkAsync(request.UserId, request.Id);

            int? categoryId = bookmark.CategoryId;

            if (categoryId != request.CategoryId)
            {
                Category category =
                    await _categoryRepository.GetCategoryAsync(request.UserId, request.CategoryId);

                categoryId = category.Id;
            }

            bookmark.Update(
                url: request.Url,
                shortDescription: request.ShortDescription,
                categoryId: categoryId);

            _bookmarkRepository.Update(bookmark);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

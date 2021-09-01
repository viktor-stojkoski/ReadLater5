namespace Services.Bookmark
{
    using System;
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
    /// Creates new bookmark.
    /// </summary>
    public record CreateBookmarkCommand(
        string Url,
        string ShortDescription,
        int CategoryId) : ICommand<Unit>;

    public class CreateBookmarkCommandHandler : ICommandHandler<CreateBookmarkCommand, Unit>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookmarkCommandHandler(
            IBookmarkRepository bookmarkRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _bookmarkRepository = bookmarkRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            Category category =
                await _categoryRepository.GetCategoryAsync(request.CategoryId);

            Bookmark bookmark = new(
                createdOn: DateTime.UtcNow,
                categoryId: category.Id,
                url: request.Url,
                shortDescription: request.ShortDescription);

            _bookmarkRepository.Insert(bookmark);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

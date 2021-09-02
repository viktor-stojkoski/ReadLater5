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
    using Shared.User.Interfaces;

    /// <summary>
    /// Updates bookmark with the given id.
    /// </summary>
    public record UpdateBookmarkCommand(
        int Id,
        string Url,
        string ShortDescription,
        int CategoryId) : ICommand<Unit>;

    public class UpdateBookmarkCommandHandler : ICommandHandler<UpdateBookmarkCommand, Unit>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateBookmarkCommandHandler(
            IBookmarkRepository bookmarkRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ICurrentUser currentUser)
        {
            _bookmarkRepository = bookmarkRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
        {
            Bookmark bookmark =
                await _bookmarkRepository.GetBookmarkAsync(_currentUser.Id, request.Id);

            int? categoryId = bookmark.CategoryId;

            if (categoryId != request.CategoryId)
            {
                Category category =
                    await _categoryRepository.GetCategoryAsync(_currentUser.Id, request.CategoryId);

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

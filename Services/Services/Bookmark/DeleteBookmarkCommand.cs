namespace Services.Bookmark
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Bookmark.Repositories;
    using Contracts.Infrastructure;

    using Entity.Bookmark;

    using MediatR;

    using Shared.Mediator;
    using Shared.User.Interfaces;

    /// <summary>
    /// Deletes bookmark.
    /// </summary>
    public record DeleteBookmarkCommand(int Id) : ICommand<Unit>;

    public class DeleteBookmarkCommandHandler : ICommandHandler<DeleteBookmarkCommand, Unit>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public DeleteBookmarkCommandHandler(
            IBookmarkRepository bookmarkRepository,
            IUnitOfWork unitOfWork,
            ICurrentUser currentUser)
        {
            _bookmarkRepository = bookmarkRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(DeleteBookmarkCommand request, CancellationToken cancellationToken)
        {
            Bookmark bookmark =
                await _bookmarkRepository.GetBookmarkAsync(_currentUser.Id, request.Id);

            bookmark.Delete(DateTime.UtcNow);

            _bookmarkRepository.Update(bookmark);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

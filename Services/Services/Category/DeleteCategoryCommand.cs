namespace Services.Category
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Category.Repositories;
    using Contracts.Infrastructure;

    using Entity.Category;

    using MediatR;

    using Shared.Mediator;
    using Shared.User.Interfaces;

    /// <summary>
    /// Deletes category.
    /// </summary>
    public record DeleteCategoryCommand(int Id) : ICommand<Unit>;

    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ICurrentUser currentUser)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category =
                await _categoryRepository.GetCategoryAsync(_currentUser.Id, request.Id);

            category.Delete(DateTime.UtcNow);

            _categoryRepository.Update(category);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

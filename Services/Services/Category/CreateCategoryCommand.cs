namespace Services.Category
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Category.Repositories;
    using Contracts.Infrastructure;

    using Entity.Category;

    using MediatR;

    using Shared.ErrorCodes;
    using Shared.Exceptions;
    using Shared.Mediator;
    using Shared.User.Interfaces;

    /// <summary>
    /// Creates new category.
    /// </summary>
    public record CreateCategoryCommand(string Name) : ICommand<Unit>;

    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ICurrentUser currentUser)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.DoesCategoryExists(_currentUser.Id, request.Name))
            {
                throw new ReadLaterAlreadyExistsException(ErrorCodes.CategoryNameAlreadyExists);
            }

            Category category = new(
                userId: _currentUser.Id,
                name: request.Name,
                createdOn: DateTime.UtcNow);

            _categoryRepository.Insert(category);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

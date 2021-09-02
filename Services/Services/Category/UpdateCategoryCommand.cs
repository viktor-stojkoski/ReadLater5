namespace Services.Category
{
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
    /// Updates category.
    /// </summary>
    public record UpdateCategoryCommand(int Id, string Name) : ICommand<Unit>;

    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            ICurrentUser currentUser)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category =
                await _categoryRepository.GetCategoryAsync(_currentUser.Id, request.Id);

            if (request.Name != category.Name
                    && await _categoryRepository.DoesCategoryExists(_currentUser.Id, request.Name))
            {
                throw new ReadLaterAlreadyExistsException(ErrorCodes.CategoryNameAlreadyExists);
            }

            category.Update(request.Name);

            _categoryRepository.Update(category);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

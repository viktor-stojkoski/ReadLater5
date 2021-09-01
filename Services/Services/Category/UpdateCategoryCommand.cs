namespace Services.Category
{
    using System.Threading;
    using System.Threading.Tasks;

    using Contracts.Category.Repositories;
    using Contracts.Exceptions;
    using Contracts.Infrastructure;

    using Entity.Category;

    using MediatR;

    using Shared.ErrorCodes;
    using Shared.Mediator;

    /// <summary>
    /// Updates category.
    /// </summary>
    public record UpdateCategoryCommand(int Id, string Name) : ICommand<Unit>;

    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetCategoryAsync(request.Id);

            if (request.Name != category.Name
                    && await _categoryRepository.DoesCategoryExists(request.Name))
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

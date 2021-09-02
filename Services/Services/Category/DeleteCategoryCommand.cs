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

    /// <summary>
    /// Deletes category.
    /// </summary>
    public record DeleteCategoryCommand(string UserId, int Id) : ICommand<Unit>;

    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category =
                await _categoryRepository.GetCategoryAsync(request.UserId, request.Id);

            category.Delete(DateTime.UtcNow);

            _categoryRepository.Update(category);

            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}

namespace Contracts.Category.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryRequest
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

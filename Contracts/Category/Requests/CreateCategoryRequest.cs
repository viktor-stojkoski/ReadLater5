namespace Contracts.Category.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryRequest
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}

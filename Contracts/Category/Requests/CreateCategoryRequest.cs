namespace Contracts.Category.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryRequest
    {
        public string UserId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}

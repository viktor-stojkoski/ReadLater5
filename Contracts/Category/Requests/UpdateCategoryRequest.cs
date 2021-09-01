namespace Contracts.Category.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCategoryRequest
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}

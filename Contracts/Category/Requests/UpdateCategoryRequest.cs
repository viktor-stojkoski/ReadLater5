namespace Contracts.Category.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCategoryRequest
    {
        public string UserId { get; set; }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}

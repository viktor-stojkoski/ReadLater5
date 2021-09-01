namespace Contracts.Category.Requests
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdateCategoryRequest
    {
        public int Id { get; set; }

        public Guid Uid { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}

namespace Entity
{
    using System.ComponentModel.DataAnnotations;

    public class Category : Entity
    {
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}

namespace Entity
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}

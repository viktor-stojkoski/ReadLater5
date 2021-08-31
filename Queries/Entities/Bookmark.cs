namespace Queries.Entities
{
    using Queries.Common.Entities;

    public class Bookmark : Entity
    {
        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

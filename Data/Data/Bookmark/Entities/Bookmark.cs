namespace Storage.Bookmark.Entities
{
    using System.ComponentModel.DataAnnotations;

    using Storage.Category.Entities;
    using Storage.Common.Entities;

    public class Bookmark : Entity
    {
        [StringLength(maximumLength: 500)]
        public string Url { get; protected internal set; }

        public string ShortDescription { get; protected internal set; }

        public int? CategoryId { get; protected internal set; }

        public virtual Category Category { get; protected internal set; }
    }
}

namespace Queries.Entities
{
    using Queries.Common.Entities;

    public class Bookmark : Entity
    {
        public string Url { get; protected internal set; }

        public string ShortDescription { get; protected internal set; }

        public string UserId { get; protected internal set; }

        public int? CategoryId { get; protected internal set; }

        public virtual Category Category { get; protected internal set; }

        public virtual ApplicationUser User { get; protected internal set; }
    }
}

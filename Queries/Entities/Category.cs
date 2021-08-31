namespace Queries.Entities
{
    using System.Collections.Generic;

    using Queries.Common.Entities;

    public class Category : Entity
    {
        public string Name { get; protected internal set; }

        public virtual ICollection<Bookmark> Bookmarks { get; protected internal set; }
    }
}

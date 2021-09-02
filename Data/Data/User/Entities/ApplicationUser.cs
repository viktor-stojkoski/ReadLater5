namespace Storage.User.Entities
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Storage.Bookmark.Entities;
    using Storage.Category.Entities;

    public class ApplicationUser : IdentityUser
    {
        public Guid Uid { get; protected internal set; }

        public DateTime CreatedOn { get; protected internal set; }

        public DateTime? DeletedOn { get; protected internal set; }

        public virtual ICollection<Category> Categories { get; protected internal set; }

        public virtual ICollection<Bookmark> Bookmarks { get; protected internal set; }
    }
}

namespace Queries.Entities
{
    using System;
    using System.Collections.Generic;

    using Queries.Common.Entities;

    public class ApplicationUser : Entity
    {
        public new string Id { get; protected internal set; }

        public string UserName { get; protected internal set; }

        public string Email { get; protected internal set; }

        public string PasswordHash { get; protected internal set; }

        public string RefreshToken { get; protected internal set; }

        public DateTime? RefreshTokenExpiresOn { get; protected internal set; }

        public virtual ICollection<Category> Categories { get; protected internal set; }

        public virtual ICollection<Bookmark> Bookmarks { get; protected internal set; }
    }
}

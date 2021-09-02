namespace Storage.Bookmark.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Storage.Category.Entities;
    using Storage.Common.Entities;
    using Storage.User.Entities;

    public class Bookmark : Entity
    {
        private Bookmark() { }

        [StringLength(maximumLength: 500)]
        public string Url { get; protected internal set; }

        public string ShortDescription { get; protected internal set; }

        public string UserId { get; protected internal set; }

        public int? CategoryId { get; protected internal set; }

        public virtual ApplicationUser User { get; protected internal set; }

        public virtual Category Category { get; protected internal set; }

        public Bookmark(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userId,
            int? categoryId,
            string url,
            string shortDescription)
        {
            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserId = userId;
            CategoryId = categoryId;
            Url = url;
            ShortDescription = shortDescription;
        }
    }
}

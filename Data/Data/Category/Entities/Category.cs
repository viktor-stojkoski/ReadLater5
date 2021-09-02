namespace Storage.Category.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Storage.Common.Entities;
    using Storage.User.Entities;

    public class Category : Entity
    {
        private Category() { }

        public string UserId { get; protected internal set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; protected internal set; }

        public virtual ApplicationUser User { get; protected internal set; }

        public Category(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userId,
            string name)
        {
            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserId = userId;
            Name = name;
        }
    }
}

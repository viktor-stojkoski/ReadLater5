namespace Storage.Category.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Storage.Common.Entities;

    public class Category : Entity
    {
        private Category() { }

        [StringLength(maximumLength: 50)]
        public string Name { get; protected internal set; }

        public Category(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string name)
        {
            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            Name = name;
        }
    }
}

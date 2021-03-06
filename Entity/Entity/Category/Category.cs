namespace Entity.Category
{
    using System;

    using Entity.Category.ValueObjects;
    using Entity.Common.Entities;

    public class Category : Entity
    {
        private Category() { }

        /// <summary>
        /// Id of the owning user.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        public CategoryNameValue Name { get; private set; }

        /// <summary>
        /// Only for mapping DB to Domain.
        /// </summary>
        public Category(
            int id,
            Guid uid,
            DateTime createdOn,
            DateTime? deletedOn,
            string userId,
            string name)
        {
            CategoryNameValue nameValue = new(name);

            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserId = userId;
            Name = nameValue;
        }

        /// <summary>
        /// Creates new category.
        /// </summary>
        public Category(string userId, DateTime createdOn, string name)
        {
            CategoryNameValue nameValue = new(name);

            Uid = Guid.NewGuid();
            CreatedOn = createdOn;
            Name = nameValue;
            UserId = userId;
        }

        /// <summary>
        /// Updates category.
        /// </summary>
        public void Update(string name)
        {
            CategoryNameValue nameValue = new(name);

            Name = nameValue;
        }

        /// <summary>
        /// Marks category as deleted.
        /// </summary>
        public void Delete(DateTime deletedOn)
        {
            DeletedOn = deletedOn;
        }
    }
}

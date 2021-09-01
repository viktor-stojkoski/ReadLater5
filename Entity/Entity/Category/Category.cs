namespace Entity.Category
{
    using System;

    using Entity.Common.Entities;

    public class Category : Entity
    {
        private Category() { }

        /// <summary>
        /// Name of the category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Only for mapping DB to Domain.
        /// </summary>
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

        /// <summary>
        /// Creates new category.
        /// </summary>
        public Category(string name, DateTime createdOn)
        {
            Uid = Guid.NewGuid();
            CreatedOn = createdOn;
            Name = name;
        }

        /// <summary>
        /// Updates category.
        /// </summary>
        public void Update(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Deletes category.
        /// </summary>
        public void Delete(DateTime deletedOn)
        {
            DeletedOn = deletedOn;
        }
    }
}

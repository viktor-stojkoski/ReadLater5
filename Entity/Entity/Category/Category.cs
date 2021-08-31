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

        public Category(string name, DateTime createdOn)
        {
            Uid = Guid.NewGuid();
            CreatedOn = createdOn;
            Name = name;
        }
    }
}

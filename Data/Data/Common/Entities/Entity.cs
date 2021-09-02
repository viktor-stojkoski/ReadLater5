namespace Storage.Common.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity
    {
        /// <summary>
        /// Entity's database id.
        /// </summary>
        [Key]
        public int Id { get; protected internal set; }

        /// <summary>
        /// Entity's unique identifier.
        /// </summary>
        public Guid Uid { get; protected internal set; }

        /// <summary>
        /// Entity's date and time of creation.
        /// </summary>
        public DateTime CreatedOn { get; protected internal set; }

        /// <summary>
        /// Entity's date and time of deletion.
        /// </summary>
        public DateTime? DeletedOn { get; protected internal set; }

        protected Entity() { }
    }
}

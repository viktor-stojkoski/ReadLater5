namespace Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity
    {
        protected Entity() { }

        [Key]
        public int ID { get; protected set; }

        public Guid Uid { get; protected set; }

        public DateTime CreatedOn { get; protected set; }

        public DateTime? DeletedOn { get; protected set; }
    }
}

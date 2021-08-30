﻿namespace Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 500)]
        public string URL { get; set; }

        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreateDate { get; set; }
    }
}

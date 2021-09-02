namespace Entity.Bookmark
{
    using System;

    using Entity.Bookmark.ValueObjects;
    using Entity.Common.Entities;

    public class Bookmark : Entity
    {
        private Bookmark() { }

        /// <summary>
        /// Bookmark's URL.
        /// </summary>
        public UrlValue Url { get; private set; }

        /// <summary>
        /// Bookmark's description.
        /// </summary>
        public string ShortDescription { get; private set; }

        /// <summary>
        /// Id of the owning user.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Id of the owning category.
        /// </summary>
        public int? CategoryId { get; private set; }

        /// <summary>
        /// Only for mapping DB to Domain.
        /// </summary>
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
            UrlValue urlValue = new(url);

            Id = id;
            Uid = uid;
            CreatedOn = createdOn;
            DeletedOn = deletedOn;
            UserId = userId;
            CategoryId = categoryId;
            Url = urlValue;
            ShortDescription = shortDescription;
        }

        /// <summary>
        /// Creates new bookmark.
        /// </summary>
        public Bookmark(
            DateTime createdOn,
            string userId,
            int? categoryId,
            string url,
            string shortDescription)
        {
            UrlValue urlValue = new(url);

            Uid = Guid.NewGuid();
            CreatedOn = createdOn;
            CategoryId = categoryId;
            UserId = userId;
            Url = urlValue;
            ShortDescription = shortDescription;
        }

        /// <summary>
        /// Updates bookmark.
        /// </summary>
        public void Update(string url, string shortDescription, int? categoryId)
        {
            UrlValue urlValue = new(url);

            CategoryId = categoryId;
            Url = urlValue;
            ShortDescription = shortDescription;
        }

        /// <summary>
        /// Marks bookmark as deleted.
        /// </summary>
        public void Delete(DateTime deletedOn)
        {
            DeletedOn = deletedOn;
        }
    }
}

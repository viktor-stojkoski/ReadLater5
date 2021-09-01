namespace Queries.Features.Bookmark.GetBookmark
{
    public class BookmarkDto
    {
        /// <summary>
        /// Bookmark's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bookmark's URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Bookmark's short description.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Bookmark's owning category.
        /// </summary>
        public BookmarkCategoryDto Category { get; set; }
    }
}

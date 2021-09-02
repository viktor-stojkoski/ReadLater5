namespace Contracts.Bookmark.Requests
{
    using System.ComponentModel.DataAnnotations;

    public class CreateBookmarkRequest
    {
        public string UserId { get; set; }

        [Url]
        public string Url { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        public int CategoryId { get; set; }
    }
}

namespace Storage.Bookmark.Mappers
{
    using Entity.Bookmark;

    internal static class BookmarkMapper
    {
        internal static Bookmark ToBookmarkDomain(this Entities.Bookmark dbBookmark) =>
            new(id: dbBookmark.Id,
                uid: dbBookmark.Uid,
                createdOn: dbBookmark.CreatedOn,
                deletedOn: dbBookmark.DeletedOn,
                categoryId: dbBookmark.CategoryId,
                userId: dbBookmark.UserId,
                url: dbBookmark.Url,
                shortDescription: dbBookmark.ShortDescription);

        internal static Entities.Bookmark ToBookmarkDb(this Bookmark domainBookmark) =>
            new(id: domainBookmark.Id,
                uid: domainBookmark.Uid,
                createdOn: domainBookmark.CreatedOn,
                deletedOn: domainBookmark.DeletedOn,
                userId: domainBookmark.UserId,
                categoryId: domainBookmark.CategoryId,
                url: domainBookmark.Url,
                shortDescription: domainBookmark.ShortDescription);
    }
}

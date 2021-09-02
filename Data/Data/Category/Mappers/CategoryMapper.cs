namespace Storage.Category.Mappers
{
    using Entity.Category;

    internal static class CategoryMapper
    {
        internal static Category ToCategoryDomain(this Entities.Category dbCategory) =>
            new(id: dbCategory.Id,
                uid: dbCategory.Uid,
                createdOn: dbCategory.CreatedOn,
                deletedOn: dbCategory.DeletedOn,
                userId: dbCategory.UserId,
                name: dbCategory.Name);

        internal static Entities.Category ToCategoryDb(this Category domainCategory) =>
            new(id: domainCategory.Id,
                uid: domainCategory.Uid,
                createdOn: domainCategory.CreatedOn,
                deletedOn: domainCategory.DeletedOn,
                userId: domainCategory.UserId,
                name: domainCategory.Name);
    }
}

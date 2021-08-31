namespace Services
{

    using Storage;

    public class CategoryService
    {
        private readonly ReadLaterDbContext _ReadLaterDataContext;

        public CategoryService(ReadLaterDbContext readLaterDataContext)
        {
            _ReadLaterDataContext = readLaterDataContext;
        }

        //public CategoryEntity CreateCategory(CategoryEntity category)
        //{
        //    _ReadLaterDataContext.Add(category);
        //    _ReadLaterDataContext.SaveChanges();
        //    return category;
        //}

        //public void UpdateCategory(CategoryEntity category)
        //{
        //    _ReadLaterDataContext.Update(category);
        //    _ReadLaterDataContext.SaveChanges();
        //}

        //public List<CategoryEntity> GetCategories()
        //{
        //    return _ReadLaterDataContext.Categories.ToList();
        //}

        //public CategoryEntity GetCategory(int Id)
        //{
        //    return _ReadLaterDataContext.Categories.Where(c => c.ID == Id).FirstOrDefault();
        //}

        //public CategoryEntity GetCategory(string Name)
        //{
        //    return _ReadLaterDataContext.Categories.Where(c => c.Name == Name).FirstOrDefault();
        //}

        //public void DeleteCategory(CategoryEntity category)
        //{
        //    _ReadLaterDataContext.Categories.Remove(category);
        //    _ReadLaterDataContext.SaveChanges();
        //}
    }
}

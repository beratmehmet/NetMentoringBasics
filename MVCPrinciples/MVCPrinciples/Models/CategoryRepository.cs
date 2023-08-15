namespace MVCPrinciples.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private MvcprinciplesContext _db;

        public CategoryRepository(MvcprinciplesContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> GetCategories
        {
            get
            {
                return _db.Categories.ToArray();
            }
        }
    }
}

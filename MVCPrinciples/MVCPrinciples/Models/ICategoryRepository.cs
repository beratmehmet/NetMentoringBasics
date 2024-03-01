namespace MVCPrinciples.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories { get; }
    }
}

namespace MVCPrinciples.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> LimitedProducts(int numberOfProducts);
        void Add(Product product);
    }
}

using Microsoft.EntityFrameworkCore;
using System.Runtime;

namespace MVCPrinciples.Models
{
    public class ProductRepository : IProductRepository
    {
        private MvcprinciplesContext _db;

        public ProductRepository(MvcprinciplesContext db)
        {
            _db = db;
        }

        public void Add(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Edit(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.FirstOrDefault(x => x.ProductId == productId) ?? throw new Exception("Not Found");
        }

        public IEnumerable<Product> LimitedProducts(int numberOfProducts)
        {
            IEnumerable<Product> products;
            if (numberOfProducts > 0)
            {
                products = _db.Products.Include(p => p.Supplier).Include(p => p.Category).Take(numberOfProducts).ToList();
            }
            else
            {
                products = _db.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
            }
            return products;
        }
    }
}

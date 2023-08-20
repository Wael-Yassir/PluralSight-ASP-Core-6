using BigPicture.Data.Models;

namespace BigPicture.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetProduct(int id);

        Task<Product> Add(Product product);
    }
}

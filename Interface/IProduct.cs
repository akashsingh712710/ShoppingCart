using Entities;
using System;

namespace Services.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync( int productId );
        Task AddProductAsync( Product product );
        Task UpdateProductAsync( Product product );
        Task DeleteProductAsync( int id );
    }
}

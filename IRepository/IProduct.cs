using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
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

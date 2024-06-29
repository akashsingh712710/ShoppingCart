using Entities;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync( int productId )
        {
            return await _context.Products.FindAsync( productId );
        }

        public async Task AddProductAsync( Product product )
        {
            _context.Products.Add( product );
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync( Product product )
        {
            _context.Products.Update( product );
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync( int id )
        {
            var product = await _context.Products.FindAsync( id );
            if(product != null)
            {
                _context.Products.Remove( product );
                await _context.SaveChangesAsync();
            }
        }
    }
}

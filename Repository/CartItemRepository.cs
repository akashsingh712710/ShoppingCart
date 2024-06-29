using Entities;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CartItemRepository : ICartItem
    {
        private readonly ApplicationDbContext _context;
        public CartItemRepository( ApplicationDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsAsync()
        {
            return await _context.CartItems.Include( ci => ci.Product ).ToListAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync( int id )
        {
            return await _context.CartItems.Include( ci => ci.Product ).FirstOrDefaultAsync( ci => ci.Id == id );
        }

        public async Task AddCartItemAsync( CartItem cartItem )
        {
            _context.CartItems.Add( cartItem );
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync( CartItem cartItem )
        {
            _context.CartItems.Update( cartItem );
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItemAsync( int id )
        {
            var cartItem = await _context.CartItems.FindAsync( id );
            if(cartItem != null)
            {
                _context.CartItems.Remove( cartItem );
                await _context.SaveChangesAsync();
            }
        }
    }
}

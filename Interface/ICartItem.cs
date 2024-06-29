using Entities;

namespace Services.Interface
{
    public interface ICartItem
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem> GetCartItemByIdAsync( int id );
        Task AddCartItemAsync( CartItem cartItem );
        Task UpdateCartItemAsync( CartItem cartItem );
        Task DeleteCartItemAsync( int id );
    }
}

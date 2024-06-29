using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart_Test.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartItem _cartItem;
        private readonly IProduct _product;

        public CartController( ICartItem cartItem, IProduct product )
        {
            _cartItem = cartItem;
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var cartItems = await _cartItem.GetCartItemsAsync();
            return View( cartItems );
        }

        public async Task<IActionResult> AddToCart( int productId )
        {
            var product = await _product.GetProductByIdAsync( productId );
            if(product == null)
            {
                return NotFound();
            }

            var cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = 1
            };

            await _cartItem.AddCartItemAsync( cartItem );
            return RedirectToAction( nameof( Index ) );
        }

        public async Task<IActionResult> RemoveFromCart( int id )
        {
            await _cartItem.DeleteCartItemAsync( id );
            return RedirectToAction( nameof( Index ) );
        }
    }
}

using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart_Test.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;
        public ProductsController( IProduct product )
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _product.GetProductsAsync();
            return View( products );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Product product )
        {
            if(ModelState.IsValid)
            {
                await _product.AddProductAsync( product );
                return RedirectToAction( nameof( Index ) );
            }
            return View( product );
        }

        public async Task<IActionResult> Edit( int? id )
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProductByIdAsync( id.Value );
            if(product == null)
            {
                return NotFound();
            }
            return View( product );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, Product product )
        {
            if(id != product.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                await _product.UpdateProductAsync( product );
                return RedirectToAction( nameof( Index ) );
            }
            return View( product );
        }

        public async Task<IActionResult> Delete( int? id )
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await _product.GetProductByIdAsync( id.Value );
            if(product == null)
            {
                return NotFound();
            }

            return View( product );
        }

        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( int id )
        {
            await _product.DeleteProductAsync( id );
            return RedirectToAction( nameof( Index ) );
        }
    }
}

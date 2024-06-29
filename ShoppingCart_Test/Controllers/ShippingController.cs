using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart_Test.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart_Test.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingMethodRepository _shippingMethodRepository;
        private readonly IBillingAddressRepository _billingAddressRepository;

        public ShippingController(IShippingMethodRepository shippingMethodRepository, IBillingAddressRepository billingAddressRepository)
        {
            _shippingMethodRepository = shippingMethodRepository;
            _billingAddressRepository = billingAddressRepository;
        }

        public async Task<IActionResult> Index()
        {
            var shippingMethods = await _shippingMethodRepository.GetAllShippingMethodsAsync();
            var viewModel = new ShippingBillingViewModel
            {
                ShippingMethods = shippingMethods.ToList(),
                BillingAddress = new BillingAddress()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ShippingBillingViewModel viewModel)
        {
                await _billingAddressRepository.AddBillingAddressAsync(viewModel.BillingAddress);

                return RedirectToAction("ReviewOrder", "Order");

            //viewModel.ShippingMethods = (await _shippingMethodRepository.GetAllShippingMethodsAsync()).ToList();
            //return View(viewModel);
        }
    }
}

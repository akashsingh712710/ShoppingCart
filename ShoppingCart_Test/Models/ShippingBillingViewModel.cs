using Entities;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart_Test.Models
{
    public class ShippingBillingViewModel
    {
        public BillingAddress BillingAddress { get; set; }

        [Required]
        public int SelectedShippingMethodId { get; set; }
        public List<ShippingMethod> ShippingMethods { get; set; }
    }
}

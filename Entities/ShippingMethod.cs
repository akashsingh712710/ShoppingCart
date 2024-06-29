using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ShippingMethod
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string MethodName { get; set; }

        [Required]
        public decimal Cost { get; set; }
    }
}

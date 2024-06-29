using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength( 30 )]
        public string ProductCode { get; set; }

        [Required, MaxLength( 100 )]
        public string ProductName { get; set; }

        [Required, MaxLength( 100 )]
        public string Manufacturer { get; set; }

        [Required, MaxLength( 100 )]
        public string ShippingNo { get; set; }

        public int? SerialNo { get; set; }

        [Required, MaxLength( 100 )]
        public string BatchNo { get; set; }

        [Required]
        public decimal MRP { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedOn { get; set; }
    }
}

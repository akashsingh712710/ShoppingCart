using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IShippingMethodRepository
    {
        Task<IEnumerable<ShippingMethod>> GetAllShippingMethodsAsync();
        Task<ShippingMethod> GetShippingMethodByIdAsync(int id);
    }
}

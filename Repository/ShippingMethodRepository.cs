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
    public class ShippingMethodRepository : IShippingMethodRepository
    {
        private readonly ApplicationDbContext _context;
        public ShippingMethodRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShippingMethod>> GetAllShippingMethodsAsync()
        {
            return await _context.ShippingMethods.ToListAsync();
        }

        public async Task<ShippingMethod> GetShippingMethodByIdAsync(int id)
        {
            return await _context.ShippingMethods.FindAsync(id);
        }
    }
}

using Entities;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BillingAddressRepository : IBillingAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public BillingAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddBillingAddressAsync(BillingAddress billingAddress)
        {
            _context.BillingAddresses.Add(billingAddress);
            await _context.SaveChangesAsync();
        }
    }
}

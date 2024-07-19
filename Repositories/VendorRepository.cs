using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(int id);
        Task<Vendor> AddVendorAsync(Vendor vendor);
        Task<Vendor> UpdateVendorAsync(Vendor vendor);
        Task<bool> DeleteVendorAsync(int id);
    }

     public class VendorRepository : IVendorRepository
    {
        private readonly VendorContext _context;

        public VendorRepository(VendorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            return await _context.Vendor.ToListAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(int id)
        {
            return await _context.Vendor.FindAsync(id);
        }

        public async Task<Vendor> AddVendorAsync(Vendor vendor)
        {
            _context.Vendor.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor> UpdateVendorAsync(Vendor vendor)
        {
            _context.Entry(vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<bool> DeleteVendorAsync(int id)
        {
            var vendor = await _context.Vendor.FindAsync(id);
            if (vendor == null)
            {
                return false;
            }

            _context.Vendor.Remove(vendor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

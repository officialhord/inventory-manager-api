using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(long id);
        Task<Vendor> AddVendorAsync(Vendor vendor);
        Task<Vendor> UpdateVendorAsync(Vendor vendor);
        Task<bool> DeleteVendorAsync(long id);
                Task<Vendor> ValidateVendorAsync(string email, string password); // New method for login

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

        public async Task<Vendor> GetVendorByIdAsync(long id)
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

        public async Task<bool> DeleteVendorAsync(long id)
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

        public async Task<Vendor> ValidateVendorAsync(string email, string password)
        {
            return await _context.Vendor
                .FirstOrDefaultAsync(v => v.email.ToLower() == email.ToLower() && v.password == password);
        }
    }
    
}

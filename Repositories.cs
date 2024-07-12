using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repositories
{

        public class VendorContext : DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
    }

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
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(int id)
        {
            return await _context.Vendors.FindAsync(id);
        }

        public async Task<Vendor> AddVendorAsync(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
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
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return false;
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

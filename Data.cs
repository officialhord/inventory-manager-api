using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class VendorContext : DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
    }
}

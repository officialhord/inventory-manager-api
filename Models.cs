namespace Models
{

       public class VendorContext : DbContext
    {
        public VendorContext(DbContextOptions<VendorContext> options)
            : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
    }
    
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

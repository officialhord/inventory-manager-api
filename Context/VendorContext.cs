using Microsoft.EntityFrameworkCore;
using Models;

public class VendorContext : DbContext
{
  public VendorContext(DbContextOptions<VendorContext> options) : base(options) { }

  public DbSet<Vendor> Vendor { get; set; } = null!;
}
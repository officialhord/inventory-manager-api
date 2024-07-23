using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoryAsync();
        Task<Inventory> GetInventoryByIdAsync(long id);
        Task<Inventory> AddInventoryAsync(Inventory Inventory);
        Task<Inventory> UpdateInventoryAsync(Inventory Inventory);
        Task<bool> DeleteInventoryAsync(long id);
    }

     public class InventoryRepository : IInventoryRepository
    {
        private readonly VendorContext _context;

        public InventoryRepository(VendorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetInventoryAsync()
        {
            return await _context.Inventory.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(long id)
        {
            return await _context.Inventory.FindAsync(id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<bool> DeleteInventoryAsync(long id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return false;
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

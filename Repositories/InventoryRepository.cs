using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task<Inventory> AddInventoryAsync(Inventory Inventory);
        Task<Inventory> UpdateInventoryAsync(Inventory Inventory);
        Task<bool> DeleteInventoryAsync(int id);
    }

     public class InventoryRepository : IInventoryRepository
    {
        private readonly VendorContext _context;

        public InventoryRepository(VendorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return false;
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
    
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryController(IInventoryRepository inventoryRepository)
    {
      _inventoryRepository = inventoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
    {
      var Inventorys = await _inventoryRepository.GetInventoryAsync();
      return Ok(Inventorys);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inventory>> GetInventory(int id)
    {
      var inventory = await _inventoryRepository.GetInventoryByIdAsync(id);
      if (inventory == null)
      {
        return NotFound();
      }

      return Ok(inventory);
    }

    [HttpPost]
    public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
    {
      var createdInventory = await _inventoryRepository.AddInventoryAsync(inventory);
      return CreatedAtAction(nameof(GetInventory), new { id = createdInventory.id }, createdInventory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Inventory>> PutInventory(int id, Inventory inventory)
    {
      if (id != inventory.id)
      {
        return BadRequest();
      }

      var updatedInventory = await _inventoryRepository.UpdateInventoryAsync(inventory);
      return Ok(updatedInventory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInventory(int id)
    {
      var result = await _inventoryRepository.DeleteInventoryAsync(id);
      if (!result)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}

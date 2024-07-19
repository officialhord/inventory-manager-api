using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorsController(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            var vendors = await _vendorRepository.GetVendorsAsync();
            return Ok(vendors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _vendorRepository.GetVendorByIdAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            var createdVendor = await _vendorRepository.AddVendorAsync(vendor);
            return CreatedAtAction(nameof(GetVendor), new { id = createdVendor.id }, createdVendor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vendor>> PutVendor(int id, Vendor vendor)
        {
            if (id != vendor.id)
            {
                return BadRequest();
            }

            var updatedVendor = await _vendorRepository.UpdateVendorAsync(vendor);
            return Ok(updatedVendor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var result = await _vendorRepository.DeleteVendorAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

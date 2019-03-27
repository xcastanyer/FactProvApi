using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactXCO.Models;

namespace FactXCO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaProveedorController : ControllerBase
    {
        private readonly Contexto _context;

        public FacturaProveedorController(Contexto context)
        {
            _context = context;
        }

        // GET: api/FacturaProveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaProveedor>>> GetFacturasProveedor()
        {
            return await _context.FacturasProveedor.ToListAsync();
        }

        // GET: api/FacturaProveedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaProveedor>> GetFacturaProveedor(int id)
        {
            var facturaProveedor = await _context.FacturasProveedor.Include(p=>p.Proveedor).FirstOrDefaultAsync(i=>i.ProveedorId == id);

            if (facturaProveedor == null)
            {
                return NotFound();
            }

            return facturaProveedor;
        }

        // PUT: api/FacturaProveedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaProveedor(int id, FacturaProveedor facturaProveedor)
        {
            if (id != facturaProveedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturaProveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FacturaProveedors
        [HttpPost]
        public async Task<ActionResult<FacturaProveedor>> PostFacturaProveedor(FacturaProveedor facturaProveedor)
        {
            _context.FacturasProveedor.Add(facturaProveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaProveedor", new { id = facturaProveedor.Id }, facturaProveedor);
        }

        // DELETE: api/FacturaProveedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacturaProveedor>> DeleteFacturaProveedor(int id)
        {
            var facturaProveedor = await _context.FacturasProveedor.FindAsync(id);
            if (facturaProveedor == null)
            {
                return NotFound();
            }

            _context.FacturasProveedor.Remove(facturaProveedor);
            await _context.SaveChangesAsync();

            return facturaProveedor;
        }

        private bool FacturaProveedorExists(int id)
        {
            return _context.FacturasProveedor.Any(e => e.Id == id);
        }
    }
}

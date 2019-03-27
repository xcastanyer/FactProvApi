using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactXCO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;

namespace FactXCO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
   
    public class ProveedorController : ControllerBase
    {
        private readonly Contexto _context;

        public ProveedorController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorModel>>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/Proveedor/5
        [HttpGet("{id}")]
        
 
        public async Task<ActionResult<ProveedorModel>> GetProveedorModel(int id)
        {
            var proveedorModel = await _context.Proveedores.FindAsync(id);

            if (proveedorModel == null)
            {
                return NotFound();
            }

            return proveedorModel;
        }

        // PUT: api/Proveedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedorModel(int id, ProveedorModel proveedorModel)
        {
            if (id != proveedorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(proveedorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorModelExists(id))
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

        // POST: api/Proveedor
        [HttpPost]
       
        public async Task<ActionResult<ProveedorModel>> PostProveedorModel(ProveedorModel proveedorModel)
        {
            _context.Proveedores.Add(proveedorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedorModel", new { id = proveedorModel.Id }, proveedorModel);
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorModel>> DeleteProveedorModel(int id)
        {
            var proveedorModel = await _context.Proveedores.FindAsync(id);
            if (proveedorModel == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedorModel);
            await _context.SaveChangesAsync();

            return proveedorModel;
        }

        private bool ProveedorModelExists(int id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }
    }
}

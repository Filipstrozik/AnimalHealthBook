using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetsController : ControllerBase
    {
        private readonly AHBContext _context;

        public VetsController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/Vets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vet>>> GetVet()
        {
          if (_context.Vet == null)
          {
              return NotFound();
          }
            return await _context.Vet.ToListAsync();
        }

        // GET: api/Vets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vet>> GetVet(int id)
        {
          if (_context.Vet == null)
          {
              return NotFound();
          }
            var vet = await _context.Vet.FindAsync(id);

            if (vet == null)
            {
                return NotFound();
            }

            return vet;
        }

        // PUT: api/Vets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVet(int id, Vet vet)
        {
            if (id != vet.Id)
            {
                return BadRequest();
            }

            _context.Entry(vet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetExists(id))
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

        // POST: api/Vets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vet>> PostVet(Vet vet)
        {
          if (_context.Vet == null)
          {
              return Problem("Entity set 'AHBContext.Vet'  is null.");
          }
            _context.Vet.Add(vet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVet", new { id = vet.Id }, vet);
        }

        // DELETE: api/Vets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVet(int id)
        {
            if (_context.Vet == null)
            {
                return NotFound();
            }
            var vet = await _context.Vet.FindAsync(id);
            if (vet == null)
            {
                return NotFound();
            }

            _context.Vet.Remove(vet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VetExists(int id)
        {
            return (_context.Vet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

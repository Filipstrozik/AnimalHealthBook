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
    public class BreedersController : ControllerBase
    {
        private readonly AHBContext _context;

        public BreedersController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/Breeders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breeder>>> GetBreeder()
        {
          if (_context.Breeder == null)
          {
              return NotFound();
          }
            return await _context.Breeder.ToListAsync();
        }

        // GET: api/Breeders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breeder>> GetBreeder(int id)
        {
          if (_context.Breeder == null)
          {
              return NotFound();
          }
            var breeder = await _context.Breeder.FindAsync(id);

            if (breeder == null)
            {
                return NotFound();
            }

            return breeder;
        }

        // PUT: api/Breeders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreeder(int id, Breeder breeder)
        {
            if (id != breeder.Id)
            {
                return BadRequest();
            }

            _context.Entry(breeder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreederExists(id))
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

        // POST: api/Breeders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Breeder>> PostBreeder(Breeder breeder)
        {
          if (_context.Breeder == null)
          {
              return Problem("Entity set 'AHBContext.Breeder'  is null.");
          }
            _context.Breeder.Add(breeder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBreeder", new { id = breeder.Id }, breeder);
        }

        // DELETE: api/Breeders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreeder(int id)
        {
            if (_context.Breeder == null)
            {
                return NotFound();
            }
            var breeder = await _context.Breeder.FindAsync(id);
            if (breeder == null)
            {
                return NotFound();
            }

            _context.Breeder.Remove(breeder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BreederExists(int id)
        {
            return (_context.Breeder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

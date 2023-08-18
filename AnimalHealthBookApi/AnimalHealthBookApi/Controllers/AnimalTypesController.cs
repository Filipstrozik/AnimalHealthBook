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
    public class AnimalTypesController : ControllerBase
    {
        private readonly AHBContext _context;

        public AnimalTypesController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/AnimalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalType>>> GetAnimalTypes()
        {
          if (_context.AnimalTypes == null)
          {
              return NotFound();
          }
            return await _context.AnimalTypes.ToListAsync();
        }

        // GET: api/AnimalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> GetAnimalType(int id)
        {
          if (_context.AnimalTypes == null)
          {
              return NotFound();
          }
            var animalType = await _context.AnimalTypes.FindAsync(id);

            if (animalType == null)
            {
                return NotFound();
            }

            return animalType;
        }

        // PUT: api/AnimalTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalType(int id, AnimalType animalType)
        {
            if (id != animalType.Id)
            {
                return BadRequest();
            }

            _context.Entry(animalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypeExists(id))
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

        // POST: api/AnimalTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalType>> PostAnimalType(AnimalType animalType)
        {
          if (_context.AnimalTypes == null)
          {
              return Problem("Entity set 'AHBContext.AnimalTypes'  is null.");
          }
            _context.AnimalTypes.Add(animalType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalType", new { id = animalType.Id }, animalType);
        }

        // DELETE: api/AnimalTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalType(int id)
        {
            if (_context.AnimalTypes == null)
            {
                return NotFound();
            }
            var animalType = await _context.AnimalTypes.FindAsync(id);
            if (animalType == null)
            {
                return NotFound();
            }

            _context.AnimalTypes.Remove(animalType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalTypeExists(int id)
        {
            return (_context.AnimalTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

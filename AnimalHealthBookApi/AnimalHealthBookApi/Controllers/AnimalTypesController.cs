using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using AnimalHealthBookApi.Dto;

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
            return await _context.AnimalTypes.Include(a => a.Breeds).ToListAsync();
        }

        // GET: api/AnimalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> GetAnimalType(Guid id)
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
        [HttpPut]
        public async Task<IActionResult> PutAnimalType(AnimalTypeEditDto animalTypeDto)
        {

            if(_context.AnimalTypes == null)
            {
                return NotFound();
            }

            if(animalTypeDto == null)
            {
                return BadRequest();
            }

            if (!AnimalTypeExists(animalTypeDto.Id))
            {
                return NotFound();
            }

            AnimalType animalType = _context.AnimalTypes.Find(animalTypeDto.Id);

            animalType.Name = animalTypeDto.Name;

            _context.Entry(animalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypeExists(animalTypeDto.Id))
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
        public async Task<ActionResult<AnimalType>> PostAnimalType(AnimalTypeCreationDto animalTypeDto)
        {
              if (_context.AnimalTypes == null)
              {
                  return Problem("Entity set 'AHBContext.AnimalTypes'  is null.");
              }

            if (animalTypeDto == null)
            {
                return BadRequest();
            }

            var animalType = new AnimalType
            {
                Name = animalTypeDto.Name
            };

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

        private bool AnimalTypeExists(Guid id)
        {
            return (_context.AnimalTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

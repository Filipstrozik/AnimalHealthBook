using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Dto;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AHBContext _context;

        public AnimalsController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
          if (_context.Animals == null)
          {
              return NotFound();
          }
            return await _context.Animals
                .Include(a => a.AnimalType)
                .Include(a => a.HealthNotes)
                .Include(a => a.Appointments)
                .ToListAsync();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
          if (_context.Animals == null)
          {
              return NotFound();
          }
            var animal = await _context.Animals.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAnimal(AnimalEditDto animalDto)
        {

            if(_context.Animals == null)
            {
                return NotFound();
            }

            if(animalDto == null)
            {
                return BadRequest();
            }

            if(!AnimalExists(animalDto.Id))
            {
                return NotFound();
            }

            Animal animal = await _context.Animals.FindAsync(animalDto.Id);

            animal.Name = animalDto.Name;
            animal.Breed = animalDto.Breed;
            animal.AnimalGenderId = animalDto.AnimalGenderId;
            animal.BirthDate = animalDto.BirthDate;
            animal.CoatColor = animalDto.CoatColor;
            animal.CoatType = animalDto.CoatType;
            animal.AnimalTypeId = animalDto.AnimalTypeId;
            animal.IsCastrated = animalDto.IsCastrated;
            animal.MicrochipNumber = animalDto.MicrochipNumber;

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(animalDto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(animal);
        }

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(AnimalCreationDto animalDto)
        {
            if (_context.Animals == null)
            {
                return Problem("Entity set 'AHBContext.Animals'  is null.");
            }

            if (animalDto == null)
            {
                return BadRequest();
            }

            Animal animal = new Animal()
            {
                Name = animalDto.Name,
                Breed = animalDto.Breed,
                BirthDate = animalDto.BirthDate,
                CoatColor = animalDto.CoatColor,
                CoatType = animalDto.CoatType,
                AnimalTypeId = animalDto.AnimalTypeId,
                IsCastrated = animalDto.IsCastrated,
                MicrochipNumber = animalDto.MicrochipNumber
            };


            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(Guid id)
        {
            if (_context.Animals == null)
            {
                return NotFound();
            }
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalExists(Guid id)
        {
            return (_context.Animals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

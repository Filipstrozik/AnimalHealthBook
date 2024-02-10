using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Dto;
using AnimalHealthBookApi.Models;
using AnimalHealthBookApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AHBContext _context;
        private readonly UserService _userService;

        public AnimalsController(
            AHBContext context,
            UserService userService
            )
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {


          if (_context.Animals == null)
          {
              return NotFound();
          }

          User user = _userService.GetUserFromRequest();

          var animals = await _context.Animals
              .Include(a => a.AnimalType)
              .Include(a => a.HealthNotes)
              .Include(a => a.Appointments)
              .Include(a => a.Users)
              .Include(a => a.AnimalType)
              .Include(a => a.Breed)
              .Include(a => a.CoatColor)
              .Include(a => a.CoatType)
              .Where(a => a.Users.Contains(user))
              .ToListAsync();

            return animals;
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(Guid id)
        {
            if (_context.Animals == null)
            {
                return NotFound();
            }

            var animal = await _context.Animals
                .Include(a => a.AnimalType)
                .Include(a => a.Breed)
                .Include(a => a.CoatColor)
                .Include(a => a.CoatType)
                .FirstOrDefaultAsync(a => a.Id == id);

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
            animal.BreedId = animalDto.BreedId;
            animal.AnimalGenderId = animalDto.AnimalGenderId;
            animal.BirthDate = animalDto.BirthDate;
            animal.CoatColorId = animalDto.CoatColorId;
            animal.CoatTypeId = animalDto.CoatTypeId;
            animal.AnimalTypeId = animalDto.AnimalTypeId;
            animal.IsCastrated = animalDto.IsCastrated;
            animal.MicrochipNumber = animalDto.MicrochipNumber;
            animal.Users = animalDto.Users;

            Breed breed = await _context.Breeds.FindAsync(animalDto.BreedId);
            CoatColor coatColor = await _context.CoatColors.FindAsync(animalDto.CoatColorId);
            CoatType coatType = await _context.CoatTypes.FindAsync(animalDto.CoatTypeId);

            if(breed == null)
            {
                return BadRequest("Breed not found.");
            }

            if (coatColor == null)
            {
                return BadRequest("Coat color not found.");
            }

            if (coatType == null)
            {
                return BadRequest("Coat type not found.");
            }

            animal.Breed = breed;
            animal.CoatColor = coatColor;
            animal.CoatType = coatType;

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

            User user = _userService.GetUserFromRequest();

            Animal animal = new Animal()
            {
                Name = animalDto.Name,
                BreedId = animalDto.BreedId,
                BirthDate = animalDto.BirthDate,
                CoatColorId = animalDto.CoatColorId,
                CoatTypeId = animalDto.CoatTypeId,
                AnimalTypeId = animalDto.AnimalTypeId,
                IsCastrated = animalDto.IsCastrated,
                MicrochipNumber = animalDto.MicrochipNumber,
                AnimalGenderId = animalDto.AnimalGenderId,
                Users = new List<User>() { user }
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

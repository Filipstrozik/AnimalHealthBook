using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Dto;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthNotesController : ControllerBase
    {

        private readonly AHBContext _context;
        public HealthNotesController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/HealthNotes
        [HttpGet]
        public ActionResult<IEnumerable<HealthNote>> Get()
        {
            if (_context.HealthNotes == null)
            {
                return NotFound();
            }
            return Ok(_context.HealthNotes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthNote>> Get(Guid id)
        {
            if(_context.HealthNotes == null)
            {
                return NotFound();
            }
            var healthNote = await _context.HealthNotes.FindAsync(id);
            if(healthNote == null)
            {
                return NotFound();
            }
            return Ok(healthNote);
        }

        [HttpPost]
        public async Task<ActionResult<HealthNote>> Post(HealthNoteCreationDto healthNoteDto)
        {
            if(_context.HealthNotes == null)
            {
                return NotFound();
            }

            if(healthNoteDto == null)
            {
                return BadRequest();
            }

            var healthNote = new HealthNote
            {
                AnimalId = healthNoteDto.AnimalId,
                Description = healthNoteDto.Description,
                Date = healthNoteDto.Date
            };

            _context.HealthNotes.Add(healthNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = healthNote.Id }, healthNote);
        }

        [HttpPut]
        public async Task<IActionResult> Put(HealthNoteEditDto healthNoteDto)
        {
            if(_context.HealthNotes == null)
            {
                return NotFound();
            }

            if(healthNoteDto == null)
            {
                return BadRequest();
            }

            var healthNote = await _context.HealthNotes.FindAsync(healthNoteDto.Id);

            if(healthNote == null)
            {
                return NotFound();
            }

            healthNote.AnimalId = healthNoteDto.AnimalId;
            healthNote.Description = healthNoteDto.Description;
            healthNote.Date = healthNoteDto.Date;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(_context.HealthNotes == null)
            {
                return NotFound();
            }
            var healthNote = await _context.HealthNotes.FindAsync(id);
            if(healthNote == null)
            {
                return NotFound();
            }
            _context.HealthNotes.Remove(healthNote);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

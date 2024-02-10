using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoatColorsController : ControllerBase
    {

        private readonly AHBContext _context;


        public CoatColorsController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/CoatColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoatColor>>> GetCoatColors()
        {
            if (_context.CoatColors == null)
            {
                return NotFound();
            }
            return await _context.CoatColors.ToListAsync();
        }

        // GET: api/CoatColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoatColor>> GetCoatColor(Guid id)
        {
            if (_context.CoatColors == null)
            {
                return NotFound();
            }
            var coatColor = await _context.CoatColors.FindAsync(id);
            if (coatColor == null)
            {
                return NotFound();
            }
            return coatColor;
        }

        // PUT: api/CoatColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCoatColor(CoatColor coatColor)
        {
            if (_context.CoatColors == null)
            {
                return NotFound();
            }
            _context.Entry(coatColor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/CoatColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoatColor>> PostCoatColor(CoatColor coatColor)
        {
            if (_context.CoatColors == null)
            {
                return NotFound();
            }
            _context.CoatColors.Add(coatColor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCoatColor", new { id = coatColor.Id }, coatColor);
        }

        // DELETE: api/CoatColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoatColor(Guid id)
        {
            if (_context.CoatColors == null)
            {
                return NotFound();
            }
            var coatColor = await _context.CoatColors.FindAsync(id);
            if (coatColor == null)
            {
                return NotFound();
            }
            _context.CoatColors.Remove(coatColor);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CoatColorExists(Guid id)
        {
            return _context.CoatColors.Any(e => e.Id == id);
        }
    }
}

using AnimalHealthBookApi.Context;
using AnimalHealthBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalHealthBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoatTypesController : ControllerBase
    {
        private readonly AHBContext _context;

        public CoatTypesController(AHBContext context)
        {
            _context = context;
        }

        // GET: api/CoatType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoatType>>> GetCoatTypes()
        {
            if (_context.CoatTypes == null)
            {
                return NotFound();
            }
            return await _context.CoatTypes.ToListAsync();
        }

        // GET: api/CoatType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoatType>> GetCoatType(Guid id)
        {
            if (_context.CoatTypes == null)
            {
                return NotFound();
            }
            var coatType = await _context.CoatTypes.FindAsync(id);
            if (coatType == null)
            {
                return NotFound();
            }
            return coatType;
        }

        // PUT: api/CoatType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCoatType(CoatType coatType)
        {
            if (_context.CoatTypes == null)
            {
                return NotFound();
            }
            _context.Entry(coatType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/CoatType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoatType>> PostCoatType(CoatType coatType)
        {
            if (_context.CoatTypes == null)
            {
                return NotFound();
            }
            _context.CoatTypes.Add(coatType);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCoatType", new { id = coatType.Id }, coatType);
        }

        // DELETE: api/CoatType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoatType(Guid id)
        {
            if (_context.CoatTypes == null)
            {
                return NotFound();
            }
            var coatType = await _context.CoatTypes.FindAsync(id);
            if (coatType == null)
            {
                return NotFound();
            }
            _context.CoatTypes.Remove(coatType);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CoatTypeExists(Guid id)
        {
            return _context.CoatTypes.Any(e => e.Id == id);
        }
    }
}

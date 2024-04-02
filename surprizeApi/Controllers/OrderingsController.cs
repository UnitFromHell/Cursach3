using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using surprizeApi.Models;

namespace surprizeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public OrderingsController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/Orderings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordering>>> GetOrderings()
        {
            return await _context.Orderings.ToListAsync();
        }

        // GET: api/Orderings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordering>> GetOrdering(int? id)
        {
            var ordering = await _context.Orderings.FindAsync(id);

            if (ordering == null)
            {
                return NotFound();
            }

            return ordering;
        }

        [HttpGet("GetByUserSiteId/{userSiteId}")]
        public async Task<ActionResult<IEnumerable<Ordering>>> GetByUserSiteId(int userSiteId)
        {
            var orderings = await _context.Orderings.Where(o => o.UserSiteId == userSiteId).ToListAsync();

            if (orderings == null || !orderings.Any())
            {
                return NotFound();
            }

            return orderings;
        }

        // PUT: api/Orderings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdering(int? id, Ordering ordering)
        {
            if (id != ordering.IdOrder)
            {
                return BadRequest();
            }

            _context.Entry(ordering).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderingExists(id))
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

        // POST: api/Orderings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordering>> PostOrdering(Ordering ordering)
        {
            _context.Orderings.Add(ordering);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdering", new { id = ordering.IdOrder }, ordering);
        }

        // DELETE: api/Orderings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdering(int? id)
        {
            var ordering = await _context.Orderings.FindAsync(id);
            if (ordering == null)
            {
                return NotFound();
            }

            _context.Orderings.Remove(ordering);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderingExists(int? id)
        {
            return _context.Orderings.Any(e => e.IdOrder == id);
        }
    }
}

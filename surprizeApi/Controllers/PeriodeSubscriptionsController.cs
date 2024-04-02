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
    public class PeriodeSubscriptionsController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public PeriodeSubscriptionsController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/PeriodeSubscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodeSubscription>>> GetPeriodeSubscriptions()
        {
            return await _context.PeriodeSubscriptions.ToListAsync();
        }

        // GET: api/PeriodeSubscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodeSubscription>> GetPeriodeSubscription(int? id)
        {
            var periodeSubscription = await _context.PeriodeSubscriptions.FindAsync(id);

            if (periodeSubscription == null)
            {
                return NotFound();
            }

            return periodeSubscription;
        }

        // PUT: api/PeriodeSubscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodeSubscription(int? id, PeriodeSubscription periodeSubscription)
        {
            if (id != periodeSubscription.IdPeriodeSubscription)
            {
                return BadRequest();
            }

            _context.Entry(periodeSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodeSubscriptionExists(id))
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

        // POST: api/PeriodeSubscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeriodeSubscription>> PostPeriodeSubscription(PeriodeSubscription periodeSubscription)
        {
            _context.PeriodeSubscriptions.Add(periodeSubscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodeSubscription", new { id = periodeSubscription.IdPeriodeSubscription }, periodeSubscription);
        }

        // DELETE: api/PeriodeSubscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodeSubscription(int? id)
        {
            var periodeSubscription = await _context.PeriodeSubscriptions.FindAsync(id);
            if (periodeSubscription == null)
            {
                return NotFound();
            }

            _context.PeriodeSubscriptions.Remove(periodeSubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeriodeSubscriptionExists(int? id)
        {
            return _context.PeriodeSubscriptions.Any(e => e.IdPeriodeSubscription == id);
        }
    }
}

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
    public class PeriodesController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public PeriodesController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/Periodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Periode>>> GetPeriodes()
        {
            return await _context.Periode.ToListAsync();
        }

        // GET: api/Periodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Periode>> GetPeriode(int? id)
        {
            var periode = await _context.Periode.FindAsync(id);

            if (periode == null)
            {
                return NotFound();
            }

            return periode;
        }

        // PUT: api/Periodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriode(int? id, Periode periode)
        {
            if (id != periode.IdPeriode)
            {
                return BadRequest();
            }

            _context.Entry(periode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodeExists(id))
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

        // POST: api/Periodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Periode>> PostPeriode(Periode periode)
        {
            _context.Periode.Add(periode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriode", new { id = periode.IdPeriode }, periode);
        }

        // DELETE: api/Periodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriode(int? id)
        {
            var periode = await _context.Periode.FindAsync(id);
            if (periode == null)
            {
                return NotFound();
            }

            _context.Periode.Remove(periode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeriodeExists(int? id)
        {
            return _context.Periode.Any(e => e.IdPeriode == id);
        }
    }
}

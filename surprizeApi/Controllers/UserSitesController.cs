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
    public class UserSitesController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public UserSitesController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/UserSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSite>>> GetUserSites()
        {
            return await _context.UserSites.ToListAsync();
        }

        // GET: api/UserSites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSite>> GetUserSite(int? id)
        {
            var userSite = await _context.UserSites.FindAsync(id);

            if (userSite == null)
            {
                return NotFound();
            }

            return userSite;
        }

        // PUT: api/UserSites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSite(int? id, UserSite userSite)
        {
            if (id != userSite.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(userSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSiteExists(id))
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

        // POST: api/UserSites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSite>> PostUserSite(UserSite userSite)
        {
            _context.UserSites.Add(userSite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSite", new { id = userSite.IdUser }, userSite);
        }

        // DELETE: api/UserSites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSite(int? id)
        {
            var userSite = await _context.UserSites.FindAsync(id);
            if (userSite == null)
            {
                return NotFound();
            }

            _context.UserSites.Remove(userSite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSiteExists(int? id)
        {
            return _context.UserSites.Any(e => e.IdUser == id);
        }
    }
}

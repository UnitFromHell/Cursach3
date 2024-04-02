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
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public UserSubscriptionsController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/UserSubscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSubscription>>> GetUserSubscriptions()
        {
            return await _context.UserSubscriptions.ToListAsync();
        }

        // GET: api/UserSubscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSubscription>> GetUserSubscription(int? id)
        {
            var userSubscription = await _context.UserSubscriptions.FindAsync(id);

            if (userSubscription == null)
            {
                return NotFound();
            }

            return userSubscription;
        }


        [HttpGet("GetByUserSiteId/{userSiteId}")]
        public async Task<ActionResult<IEnumerable<UserSubscription>>> GetUserSubscriptionsByUserSiteId(int userSiteId)
        {
            var userSubscriptions = await _context.UserSubscriptions
                .Where(u => u.UserSiteId == userSiteId && u.IsFavourite == true)
                .ToListAsync();

            if (userSubscriptions == null || !userSubscriptions.Any())
            {
                return NotFound();
            }

            return userSubscriptions;
        }

        // PUT: api/UserSubscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSubscription(int? id, UserSubscription userSubscription)
        {
            if (id != userSubscription.IdUserSubscription)
            {
                return BadRequest();
            }

            _context.Entry(userSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSubscriptionExists(id))
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

        // POST: api/UserSubscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSubscription>> PostUserSubscription(UserSubscription userSubscription)
        {
            _context.UserSubscriptions.Add(userSubscription);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserSubscription", new { id = userSubscription.IdUserSubscription }, userSubscription);
        }

        // DELETE: api/UserSubscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSubscription(int? id)
        {
            var userSubscription = await _context.UserSubscriptions.FindAsync(id);
            if (userSubscription == null)
            {
                return NotFound();
            }

            _context.UserSubscriptions.Remove(userSubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSubscriptionExists(int? id)
        {
            return _context.UserSubscriptions.Any(e => e.IdUserSubscription == id);
        }
    }
}

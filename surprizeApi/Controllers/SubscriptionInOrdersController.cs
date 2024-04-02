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
    public class SubscriptionInOrdersController : ControllerBase
    {
        private readonly SurpriseBoxContext _context;

        public SubscriptionInOrdersController(SurpriseBoxContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionInOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionInOrder>>> GetSubscriptionInOrders()
        {
            return await _context.SubscriptionInOrders.ToListAsync();
        }

        // GET: api/SubscriptionInOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionInOrder>> GetSubscriptionInOrder(int? id)
        {
            var subscriptionInOrder = await _context.SubscriptionInOrders.FindAsync(id);

            if (subscriptionInOrder == null)
            {
                return NotFound();
            }

            return subscriptionInOrder;
        }

        // PUT: api/SubscriptionInOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionInOrder(int? id, SubscriptionInOrder subscriptionInOrder)
        {
            if (id != subscriptionInOrder.IdSubscriptionInOrder)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionInOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionInOrderExists(id))
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

        // POST: api/SubscriptionInOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionInOrder>> PostSubscriptionInOrder(SubscriptionInOrder subscriptionInOrder)
        {
            _context.SubscriptionInOrders.Add(subscriptionInOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionInOrder", new { id = subscriptionInOrder.IdSubscriptionInOrder }, subscriptionInOrder);
        }

        // DELETE: api/SubscriptionInOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionInOrder(int? id)
        {
            var subscriptionInOrder = await _context.SubscriptionInOrders.FindAsync(id);
            if (subscriptionInOrder == null)
            {
                return NotFound();
            }

            _context.SubscriptionInOrders.Remove(subscriptionInOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionInOrderExists(int? id)
        {
            return _context.SubscriptionInOrders.Any(e => e.IdSubscriptionInOrder == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF.Card;
using Model.Models;

namespace API.Card.Controllers
{
    [Produces("application/json")]
    [Route("api/Bank")]
    public class BankController : Controller
    {
        private readonly CardContext _context;

        public BankController(CardContext context)
        {
            _context = context;
        }

        // GET: api/Bank
        [HttpGet]
        public IEnumerable<Bank> GetBanks()
        {
            return _context.Banks;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank = await _context.Banks.SingleOrDefaultAsync(m => m.Id == id);

            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank([FromRoute] string id, [FromBody] Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank.Id)
            {
                return BadRequest();
            }

            _context.Entry(bank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        // POST: api/Bank
        [HttpPost]
        public async Task<IActionResult> PostBank([FromBody] Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Banks.Add(bank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBank", new { id = bank.Id }, bank);
        }

        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank = await _context.Banks.SingleOrDefaultAsync(m => m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();

            return Ok(bank);
        }

        private bool BankExists(string id)
        {
            return _context.Banks.Any(e => e.Id == id);
        }
    }
}
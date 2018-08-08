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
    public class BankController : BaseController
    {
        public BankController(CardContext cardContext) : base(cardContext)
        {
        }

        // GET: api/Bank
        [HttpGet]
        public IEnumerable<Bank> GetBanks()
        {
            return _cardContext.Banks;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank = await _cardContext.Banks.SingleOrDefaultAsync(m => m.Id == id);

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

            _cardContext.Entry(bank).State = EntityState.Modified;

            try
            {
                await _cardContext.SaveChangesAsync();
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

            _cardContext.Banks.Add(bank);
            await _cardContext.SaveChangesAsync();

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

            var bank = await _cardContext.Banks.SingleOrDefaultAsync(m => m.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            _cardContext.Banks.Remove(bank);
            await _cardContext.SaveChangesAsync();

            return Ok(bank);
        }

        private bool BankExists(string id)
        {
            return _cardContext.Banks.Any(e => e.Id == id);
        }
    }
}
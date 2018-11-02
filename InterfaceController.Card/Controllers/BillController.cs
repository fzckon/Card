using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EF.Card;
using EF.Log;
using Model.Models;
using EF.Card.Respository;

namespace InterfaceController.Card.Controllers
{
    [Produces("application/json")]
    [Route("api/Bill")]
    public class BillController : BaseController
    {
        private BillRepository billRepo;
        protected override void Dispose(bool disposing)
        {
            if (billRepo != null) billRepo.Dispose();
            base.Dispose(disposing);
        }

        public BillController(CardContext cardContext) : base(cardContext)
        {
            billRepo = new BillRepository(_cardContext);
        }

        // GET: api/Bill
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] BillQuery query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (query.UserId == Guid.Empty)
            {
                return BadRequest();
            }

            var bills = await billRepo.GetAsync(query);

            return Ok(bills);
        }

        // GET: api/Bill/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bill = await billRepo.FirstOrDefaultAsync(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // PUT: api/Bill/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.Id)
            {
                return BadRequest();
            }

            try
            {
                await billRepo.UpdateAsync(bill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
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

        // POST: api/Bill
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bill = await billRepo.InsertAsync(bill);

            return CreatedAtAction("Get", new { id = bill.Id }, bill);
        }

        // DELETE: api/Bill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Exists(id))
            {
                return NotFound();
            }

            await billRepo.DeleteAsync(id);

            return Ok();
        }

        private bool Exists(Guid id)
        {
            return billRepo.Exists(e => e.Id == id);
        }
    }
}
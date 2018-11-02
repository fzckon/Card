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
    [Route("api/Card")]
    public class CardController : BaseController
    {
        private CardRepository cardRepo;
        protected override void Dispose(bool disposing)
        {
            if (cardRepo != null) cardRepo.Dispose();
            base.Dispose(disposing);
        }

        public CardController(CardContext cardContext) : base(cardContext)
        {
            cardRepo = new CardRepository(_cardContext);
        }

        // GET: api/Card
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] CardInfo card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (card.UserId == Guid.Empty)
            {
                return BadRequest();
            }

            var cards = cardRepo.GetAsync(card);

            return Ok(cards);
        }

        // GET: api/Card/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await cardRepo.FirstOrDefaultAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CardInfo card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.Id)
            {
                return BadRequest();
            }

            try
            {
                card.Pre();
                await cardRepo.UpdateAsync(card);
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

        // POST: api/Card
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CardInfo card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            card.Pre();
            card = await cardRepo.InsertAsync(card);

            return CreatedAtAction("Get", new { id = card.Id }, card);
        }

        // DELETE: api/Card/5
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

            await cardRepo.DeleteAsync(id);

            return Ok();
        }

        private bool Exists(Guid id)
        {
            return cardRepo.Exists(e => e.Id == id);
        }
    }
}
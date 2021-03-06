﻿using System;
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
    [Route("api/Bank")]
    public class BankController : BaseController
    {
        private BankRepository bankRepo;
        protected override void Dispose(bool disposing)
        {
            if (bankRepo != null) bankRepo.Dispose();
            base.Dispose(disposing);
        }

        public BankController(CardContext cardContext) : base(cardContext)
        {
            bankRepo = new BankRepository(_cardContext);
        }

        // GET: api/Bank
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banks = await bankRepo.GetListAsync();

            return Ok(banks);
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bank = await bankRepo.FirstOrDefaultAsync(id);

            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        // PUT: api/Bank/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank.Id)
            {
                return BadRequest();
            }

            try
            {
                await bankRepo.UpdateAsync(bank);
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

        // POST: api/Bank
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bank = await bankRepo.InsertAsync(bank);

            return CreatedAtAction("GetBank", new { id = bank.Id }, bank);
        }

        // DELETE: api/Bank/5
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

            await bankRepo.DeleteAsync(id);

            return Ok();
        }

        private bool Exists(Guid id)
        {
            return bankRepo.Exists(e => e.Id == id);
        }
    }
}
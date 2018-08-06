using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Card.Respository
{
    public class BankRespository : BaseRepository<Bank>
    {
        private readonly CardContext _cardContext = null;

        public BankRespository(CardContext cardContext) : base(cardContext)
        {
            _cardContext = cardContext;
        }
        
    }
}

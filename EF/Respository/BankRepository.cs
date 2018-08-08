using EF.Core;
using EF.Core.Repository;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Card.Respository
{
    public class BankRepository : BaseRepository<Bank, string>
    {
        private CardContext _cardContext = null;
        public BankRepository(CardContext cardContext) : base(cardContext)
        {
            _cardContext = cardContext;
        }

        private void test()
        {
           
        }
    }
}

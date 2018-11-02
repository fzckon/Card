using EF.Core;
using EF.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Card.Respository
{
    public class CardRepository : BaseRepository<CardInfo, Guid>, ICardRepository
    {
        private CardContext _cardContext = null;
        public CardRepository(CardContext cardContext) : base(cardContext)
        {
            _cardContext = cardContext;
        }

        public async Task<IQueryable<CardInfo>> GetAsync(CardInfo query)
        {
            //var cardIds = _cardContext.CardShares.AsNoTracking().Where(t => t.UserId == query.UserId && t.CardShareStatus == CardShareStatus.Normal).Select(t => t.CardId);

            //var cards = await GetListAsync(t => t.UserId == query.UserId || cardIds.Contains(t.Id));
            var cards = await GetListAsync(t => t.UserId == query.UserId
            || _cardContext.CardShares.AsNoTracking().Any(t1 => t1.UserId == query.UserId && t1.CardShareStatus == CardShareStatus.Normal && t1.UserId == t.Id));

            if (!string.IsNullOrEmpty(query.CardNo))
                cards = cards.Where(t => t.CardNo.Contains(query.CardNo));

            return cards;

        }
    }

    public interface ICardRepository
    {
        Task<IQueryable<CardInfo>> GetAsync(CardInfo query);
    }
}

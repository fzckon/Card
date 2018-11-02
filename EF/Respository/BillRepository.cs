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
    public class BillRepository : BaseRepository<Bill, Guid>, IBillRepository
    {
        private CardContext _cardContext = null;
        public BillRepository(CardContext cardContext) : base(cardContext)
        {
            _cardContext = cardContext;
        }

        public async Task<IQueryable<Bill>> GetAsync(BillQuery query)
        {
            //var cardIds = _cardContext.CardShares.AsNoTracking().Where(t => t.UserId == query.UserId && t.CardShareStatus == CardShareStatus.Normal).Select(t => t.CardId);
            //cardIds = cardIds.Union(_cardContext.CardInfos.AsNoTracking().Where(t => t.UserId == query.UserId && t.CardStatus == CardStatus.Normal).Select(t => t.Id));

            //var bills = await GetListAsync(t => cardIds.Contains(t.CardId));
            var bills = await GetListAsync(t =>
             _cardContext.CardInfos.AsNoTracking().Any(t1 => t1.UserId == query.UserId && t1.CardStatus == CardStatus.Normal && t1.UserId == t.Id)
             || _cardContext.CardShares.AsNoTracking().Any(t2 => t2.UserId == query.UserId && t2.CardShareStatus == CardShareStatus.Normal && t2.UserId == t.Id));

            if (query.BillStatus > 0)
                bills = bills.Where(t => t.BillStatus == query.BillStatus);

            bills.OrderByDescending(t => t.CreateTime).ThenByDescending(t => t.BillingDate).ThenByDescending(t => t.RepayDate);

            return bills;
        }
    }

    public interface IBillRepository
    {
        Task<IQueryable<Bill>> GetAsync(BillQuery query);
    }
}

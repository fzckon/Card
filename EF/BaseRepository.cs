using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EF.Card
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly CardContext _cardContext = null;
        private readonly DbSet<T> _card;

        public BaseRepository(CardContext cardContext)
        {
            _cardContext = cardContext;
            _card = _cardContext.Set<T>();
        }

        public long Count()
        {
            return _card.LongCount();
        }

        public void Delete(T entity)
        {
            _card.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _card.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAllList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null) return _card;
            return _card.Where(predicate);
        }

        public void Insert(T entity)
        {
            _card.Add(entity);
        }

        public void Update(T entity)
        {
            _card.Attach(entity);
            _cardContext.Entry(entity).State = EntityState.Modified;
        }

    }
}

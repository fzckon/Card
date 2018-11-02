using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF.Core.Repository
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        #region Find
        TEntity Find(TPrimaryKey id);
        Task<TEntity> FindAsync(TPrimaryKey id);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(TPrimaryKey id);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        //TEntity Load(TPrimaryKey id);
        #endregion

        #region List
        IQueryable<TEntity> GetList();
        Task<IQueryable<TEntity>> GetListAsync();
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        T Query<T>(Func<IQueryable<T>, T> queryMethod);
        #endregion

        #region Insert
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TPrimaryKey InsertAndGetKey(TEntity entity);
        Task<TPrimaryKey> InsertAndGetKeyAsync(TEntity entity);
        #endregion

        #region Update
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Update(TEntity entity, object include, object exclude);
        Task<TEntity> UpdateAsync(TEntity entity, object include, object exclude);

        #endregion

        #region Save
        TEntity Save(TEntity entity);
        Task<TEntity> SaveAsync(TEntity entity);
        TPrimaryKey SaveGetKey(TEntity entity);
        Task<TPrimaryKey> SaveGetKeyAsync(TEntity entity);
        IEnumerable<TEntity> Save(IEnumerable<TEntity> entitys);
        IEnumerable<TEntity> SaveAsync(IEnumerable<TEntity> entitys);
        #endregion

        #region Delete
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(TPrimaryKey id);
        Task DeleteAsync(TPrimaryKey id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        void Delete(IEnumerable<TEntity> entitys);
        Task DeleteAsync(IEnumerable<TEntity> entitys);
        void Delete(IEnumerable<TPrimaryKey> ids);
        Task DeleteAsync(IEnumerable<TPrimaryKey> ids);
        #endregion

        #region Other
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        long LongCount();
        Task<long> LongCountAsync();
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion


    }
}

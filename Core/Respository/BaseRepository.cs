using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Repository
{
    public class BaseRepository<TEntity, TPrimaryKey> : IDisposable, IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                    UnitOfWork.Dispose();
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BaseRepository() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }

        #endregion

        protected readonly DbContext _context = null;
        protected readonly DbSet<TEntity> _set;
        public readonly UnitOfWork UnitOfWork = null;
        public bool IsCommit = true;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
            UnitOfWork = new UnitOfWork(_context);
        }

        #region Get
        public TEntity Get(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }
        
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetList
        public IQueryable<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<T>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Insert
        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey InsertAndGetKey(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> InsertAndGetKeyAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update
        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Save
        public TEntity Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SaveAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TPrimaryKey SaveGetKey(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TPrimaryKey> SaveGetKeyAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Save(IEnumerable<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> SaveAsync(IEnumerable<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TPrimaryKey> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IEnumerable<TPrimaryKey> ids)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Other
        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #endregion
        
    }
}

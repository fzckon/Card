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
                    uow.Dispose();
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
        public readonly UnitOfWork uow = null;
        public bool IsCommit = true;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
            uow = new UnitOfWork(_context);
        }

        #region Find
        public TEntity Find(TPrimaryKey id)
        {
            return _set.Find(id);
        }

        public Task<TEntity> FindAsync(TPrimaryKey id)
        {
            return _set.FindAsync(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Single(predicate);
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.SingleAsync(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.SingleOrDefault(predicate);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.SingleOrDefaultAsync(predicate);
        }

        public TEntity FirstOrDefault(TPrimaryKey id)
        {
            TEntity entity = Find(id);
            if (entity == null) return default(TEntity);
            return entity;
        }

        public Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            Task<TEntity> entity = FindAsync(id);
            if (entity == null) return default(Task<TEntity>);
            return entity;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.FirstOrDefault(predicate);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.FirstOrDefaultAsync(predicate);
        }

        #endregion

        #region List
        public IQueryable<TEntity> GetList()
        {
            return _set.AsNoTracking();
        }

        public Task<IQueryable<TEntity>> GetListAsync()
        {
            return Task.Run(() => GetList());
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate).AsNoTracking();
        }

        public Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.Run(() => GetList(predicate));
        }

        public T Query<T>(Func<IQueryable<T>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Insert
        public TEntity Insert(TEntity entity)
        {
            _set.Add(entity);
            if (IsCommit) uow.SaveChanges();
            return entity;
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            _set.AddAsync(entity);
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => entity);
        }

        public virtual TPrimaryKey InsertAndGetKey(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TPrimaryKey> InsertAndGetKeyAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Update
        public TEntity Update(TEntity entity)
        {
            _set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            if (IsCommit) uow.SaveChanges();
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            _set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => entity);
        }

        public TEntity Update(TEntity entity, object include, object exclude)
        {

            foreach (var inc in include.GetType().GetProperties())
            {
                _context.Entry(entity).Property(inc.Name).IsModified = true;
            }
            foreach (var exc in exclude.GetType().GetProperties())
            {
                _context.Entry(entity).Property(exc.Name).IsModified = false;
            }

            if (IsCommit) uow.SaveChanges();
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, object include, object exclude)
        {

            foreach (var inc in include.GetType().GetProperties())
            {
                _context.Entry(entity).Property(inc.Name).IsModified = true;
            }
            foreach (var exc in exclude.GetType().GetProperties())
            {
                _context.Entry(entity).Property(exc.Name).IsModified = false;
            }
            
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => entity);
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
            _set.Attach(entity);
            _set.Remove(entity);
            if (IsCommit) uow.SaveChanges();
        }

        public Task DeleteAsync(TEntity entity)
        {
            _set.Attach(entity);
            _set.Remove(entity);
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => { });
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        public Task DeleteAsync(TPrimaryKey id)
        {
            var entity = Find(id);
            DeleteAsync(entity);
            return Task.Run(() => { });
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitys = _set.Where(predicate);
            foreach (var entity in entitys)
            {
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChanges();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entitys = _set.Where(predicate);
            foreach (var entity in entitys)
            {
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => { });
        }

        public void Delete(IEnumerable<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChanges();
        }

        public Task DeleteAsync(IEnumerable<TEntity> entitys)
        {
            foreach (var entity in entitys)
            {
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChangesAsync();
            return Task.Run(() => { });
        }

        public void Delete(IEnumerable<TPrimaryKey> ids)
        {
            foreach (var id in ids)
            {
                var entity = Find(id);
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChanges();
        }

        public Task DeleteAsync(IEnumerable<TPrimaryKey> ids)
        {
            foreach (var id in ids)
            {
                var entity = Find(id);
                _set.Attach(entity);
                _set.Remove(entity);
            }
            if (IsCommit) uow.SaveChanges();
            return Task.Run(() => { });
        }

        #endregion

        #region Other
        public int Count()
        {
            return _set.Count();
        }

        public Task<int> CountAsync()
        {
            return _set.CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Count(predicate);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.CountAsync(predicate);
        }

        public long LongCount()
        {
            return _set.LongCount();
        }

        public Task<long> LongCountAsync()
        {
            return _set.LongCountAsync();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.LongCount(predicate);
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.LongCountAsync(predicate);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Any(predicate);
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.AnyAsync(predicate);
        }

        #endregion

    }
}

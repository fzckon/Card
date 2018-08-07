using EF.Card.Respository;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;

namespace EF.Card
{
    public class CardContext : DbContext
    {

        private static CardContext cardContext;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            cardContext = (CardContext)serviceProvider.GetService(typeof(CardContext));

            //do your something
        }

        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CardInfo> CardInfos { get; set; }
        public DbSet<CardShare> CardShares { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPwd> UserPwds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");

        }

        //public static string ConnectionString { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //配置数据链接
        //    optionsBuilder.UseSqlServer(ConnectionString, b => b.UseRowNumberForPaging());
        //}
    }

    public partial class RepositoryService : IDisposable
    {
        private CardContext cardContext;

        internal RepositoryService()
        {
            
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~EntityRepositoryService() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
    public partial class RepositoryService
    {
        private BankRespository privateBankRespository;
        public BankRespository Bank
        {
            get
            {
                if (privateBankRespository == null) privateBankRespository = new BankRespository(cardContext);
                return privateBankRespository;
            }
        }
    }
}

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
    
}

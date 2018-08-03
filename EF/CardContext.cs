using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;

namespace EF
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardShare> CardShares { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPwd> UserPwds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //注入Sql链接字符串
            optionsBuilder.UseSqlServer(@"Server=.;Database=Card;Trusted_Connection=True;");
        }
    }
}

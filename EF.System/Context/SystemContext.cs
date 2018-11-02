using EF.System.Respository;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;

namespace EF.System
{
    public class SystemContext : DbContext
    {

        private static SystemContext cardContext;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            cardContext = (SystemContext)serviceProvider.GetService(typeof(SystemContext));

            //do your something
        }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }
        
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

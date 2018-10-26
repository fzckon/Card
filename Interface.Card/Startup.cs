using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.Card;
using EF.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Interface.Card
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<CardContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Card"), //读取配置文件中的链接字符串
                        b => b.UseRowNumberForPaging());  //配置分页 使用旧方式
                })
                .AddDbContext<LogContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Log"), //读取配置文件中的链接字符串
                        b => b.UseRowNumberForPaging());  //配置分页 使用旧方式
                })
                ;

            services.AddMvc();
            IServiceProvider service = services.BuildServiceProvider();


        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //否则，导向错误页面
                app.UseExceptionHandler("/Base/Error");
            }

            app.UseMvc();

            //允许访问wwwroot文件夹下的静态文件
            app.UseStaticFiles();

            //设置身份验证方式
            app.UseAuthentication();

            // 设置MVC路由
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            try
            {
                using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    //LogContext.Initialize(serviceScope.ServiceProvider);
                    serviceScope.ServiceProvider.GetService<CardContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<LogContext>().Database.Migrate();
                }
            }
            catch { }
            loggerFactory.AddNLog();
            //app.AddNLogWeb();
            env.ConfigureNLog("NLog.config");
            //LogManager.Configuration.Variables["connectionString"] = Configuration.GetConnectionString("DefaultConnection");//${var:connectionString}


        }


    }
}

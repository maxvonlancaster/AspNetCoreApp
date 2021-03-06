using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCoreApp.BLL.Const;
using AspNetCoreApp.BLL.Interfaces;
using AspNetCoreApp.BLL.Services;
using AspNetCoreApp.DAL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreApp
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<SyncService>();

            services.AddMvc();
            // Also AddMvcCore - base without authorization and stuff; AddControllersWithViews - con-s + views only;
            // AddControllers - add only con-rs

            services.AddDbContext<PresentationContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Secrets.TelegramToken = Configuration.GetSection("token").Value;

            //services.AddScoped<ISyncService, SyncService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPresentationService, PresentationService>();
            services.AddScoped<IQuestionService, QuestionService>();
            //services.AddSingleton<IHostedService, SyncService>();

            // configuration of cookies 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login"); // path that the user will 
                    // be redirected if accessed priv. resources
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication(); // authentication (who is the user)
            app.UseAuthorization(); // authorisation (what rights the user has)

            //var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
            //if (appAssembly != null)
            //{ 
            //    Configuration.Add
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}

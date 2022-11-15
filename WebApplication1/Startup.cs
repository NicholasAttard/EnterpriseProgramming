using BusinessLogic.Services;
using DataAccess.Context;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1
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
            services.AddDbContext<ShoppingCartContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ShoppingCartContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //In this invertion of Control class, we are going to let it know what instances may be asked at a longer stage to be created here
            //the Startup.cs needs to know the life expectancy the service class needs to be created with

            //Transient
            //Scoped
            //Singleton

            /*
                Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime. 
                i.e if there are 50 users browsing your website, only one instance will be created and shared among all the users.
             */
            /*
                Transient: IoC will create a new instance of the spedcified service tyoe every time you ask for it.
                eg: if there are 50 users and there is a request for ItemService, then 50 instances will be created
                eg: if there are 50 users and there are 2 calls for ItemsRepository (within ItemService), then 50*2 instances are created
             */
            /*
                Scope:IoC will create an instance of the specified service type once per request and will be shared in a single request
                eg:if there are 50 users and there is 2 calls for ItemsRepository (within the ItemService), then 50*1 instances of ItemRepository
             */
            services.AddScoped<ItemsServices>();
            services.AddScoped<ItemsRepository>();

            //We are instructint the clr so that when it comes across ICategoryRepository(in the contructor), it should initialise
            //the class declared after the comma (CategoriesFileRepositpries)
            FileInfo fi = new FileInfo(@"C:\EnterpriseProgramming\EnterpriseProgramming\WebApplication1\Data\categories.txt");

            //services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesFileRepository>(x=> new CategoriesFileRepository(fi));
            services.AddScoped<CategoriesServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

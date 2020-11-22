using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebSite.Models;

namespace WebSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDatabaseContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            //for store identity of user in db contect
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDatabaseContext>();
            //services.AddScoped<IProductRepository, Productrepository>();
            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepositoryDatabase>();
            services.AddScoped<ICategoryRepository, CategoryRepositoryDatabase>();
            services.AddScoped<IOrderRepository, OrderRepository>();


            //Shopping Cart Session
            services.AddScoped<ShoppingCart>(sp 
                                                => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();


            services.AddControllersWithViews();
            //to use razor pages of identity
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //1
            app.UseHttpsRedirection();
            //2
            app.UseStaticFiles();
            //before use routing use session 
            app.UseSession();
                
            app.UseRouting();
            //to  use asp net core identity
            app.UseAuthentication();
            //to allow user log in first
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //for use razor pages of identity
                endpoints.MapRazorPages();
            });


        }
    }
}

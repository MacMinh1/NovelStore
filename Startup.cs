using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NovelStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovelStore
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
            services.AddControllersWithViews();
            services.AddDbContext<NovelStoreDbContext>(opts => {opts.UseSqlServer(Configuration["ConnectionStrings:NovelStoreConnection"]);
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<INovelStoreRepository,EFNovelStoreRepository>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();
            services.AddScoped<MyCart>(sp => MySessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            // old URL: http://localhost:44333/?novelPage=2
            // new URL: https://localhost:44333/Novels/2
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("genpage",
                "{genre}/{novellPage:int}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "{novelPage:int}",
                new { Controller = "Home", action = "Index", novelPage = 1 });
                endpoints.MapControllerRoute("genre", "{genre}",
                new { Controller = "Home", action = "Index", novelPage = 1 });
                endpoints.MapControllerRoute("pagination",
                "Novels/{novelPage}",
                new { Controller = "Home", action = "Index", novelPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}",
               "/Admin/Index");
            });
            SeedData.EnsurePopulated(app);

        }
    }
}

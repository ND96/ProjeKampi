using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Publishte açýlmasý gerek satýr
            builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Identity konfigürasyonu
            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<Context>() // DbContext'ini burada tanýmlamalýsýn
            .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Servisi DI Containera kaydetme 
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDAL, EfCategoryRepository> ();

            //builder.Services.AddSession();

            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            builder.Services.AddMvc();
            //builder.Services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(x =>
            //    {
            //        x.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            //        x.AccessDeniedPath = new PathString("/Login/AccessDenied/");
            //        x.LoginPath = "/Login/Index";
            //    }
            //    );

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.AccessDeniedPath = "/Login/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseStatusCodePages();




            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Blog}/{action=Index}/{id?}"
                );
            });



            app.Run();
        }
    }
}

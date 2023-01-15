using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InformsISG.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using InformsISG.Services.AutoMapper;
using Microsoft.EntityFrameworkCore;
using InformsISG.Data.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace InformsISG.WebApp 
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

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<InformsISGContext>();

            services.AddControllersWithViews();


            //services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            //{
            //    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //});

            services.AddSession();
            services.LoadMyServices();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, x =>
            {
                x.LoginPath = new PathString("/Home/GirisYap");//Eðer kullanýcý girilmemisse
                x.LogoutPath = new PathString("/Home/Logout");
                x.Cookie = new CookieBuilder
                {
                    Name = "InformsISG",//Çerezin Adý
                    HttpOnly = true, //Local dosyayý þifreler.JS ile okunmasýný engeller.
                    SameSite = SameSiteMode.Strict,//Fake sitelerden gelen çerezleri kabul etme
                    SecurePolicy = CookieSecurePolicy.SameAsRequest,//Always = tüm http leri kabul etmez . Ssl aldýktan sonraalways yap
                };

                x.SlidingExpiration = true;//false yaparsak sonsuza kadar açýk kalýr
                x.ExpireTimeSpan = System.TimeSpan.FromDays(1);//kullanýcý birsey yapmazsa 20 saat sonra cýkýs yapacak
                //x.AccessDeniedPath = new PathString("Home/GirisYap");

            });

           

            services.AddAutoMapper(typeof(MapProfile));
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAntiforgery();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
          

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

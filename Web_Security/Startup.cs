using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Security.Authorization;

namespace Web_Security
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
            services.AddAuthentication("MyCookiesAuth").AddCookie("MyCookiesAuth", options =>{
                options.Cookie.Name = "MyCookiesAuth";

               options.LoginPath = "/Account/Login";

                options.AccessDeniedPath = "/Account/AccessDenied"; //be default its goes to this page
               options.ExpireTimeSpan = TimeSpan.FromMinutes(2);//cookies time is 30 s  authentication cookies

              //  options.ExpireTimeSpan = TimeSpan.FromMinutes(2);//cookies time is 2 m authentication cookies
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyCategory", oplicy => oplicy.RequireClaim("Cat"));

                options.AddPolicy("OnlyAdmin", oplicy => oplicy.RequireClaim("Admin1"));

                options.AddPolicy("AdminOnly", oplicy => oplicy.RequireClaim("Admin"));
                options.AddPolicy("MustBelondToHrDepartment", policy => policy.RequireClaim("Department", "HR"));

                options.AddPolicy("HrManagerOnly", oplicy => oplicy.RequireClaim
                ("Department","HR").RequireClaim("Manager").Requirements.Add(new HrManagerProvationRequirement(3)));//ADD 3 MONTH
            });


            services.AddSingleton<IAuthorizationHandler, HrManagerProvationRequirementHandler>();
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

            app.UseRouting();

            //Middleware the security whtich is resposible to call authtication handler.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

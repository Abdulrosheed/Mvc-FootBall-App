using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballWebApp.Context;
using FootballWebApp.Implementations;
using FootballWebApp.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballWebApp
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
            services.AddDbContext<FootBallApplicationDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("FootBallContext")));
            services.AddControllersWithViews();
            services.AddScoped<IClubRepository , ClubRepository>();
            services.AddScoped<IPlayerRepository , PlayerRepository>();
            services.AddScoped<ISponsorerRepository , SponsorerRepository>();
            services.AddScoped<IClubService , ClubService>();
            services.AddScoped<IPlayerService , PlayerService>();
            services.AddScoped<ISponsorerService , SponsorerService>();
            services.AddSession();
            services.AddAuthentication();
            services.AddAuthorization();
            
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
            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Player}/{action=LoginPage}/{id?}");
            });
        }
    }
}

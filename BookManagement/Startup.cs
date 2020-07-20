using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookManagement.Models;
using BookManagement.Models.TheLoaiTruyen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookManagement
{
    public class Startup
    {
        private readonly IConfiguration confish;

        public Startup(IConfiguration confish)
        {
            this.confish = confish;
        }

      

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IBookRespository, SqlBookRepository>();
            services.AddScoped<ITheLoaiRepository, SqlTheLoaiRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(confish.GetConnectionString("BooksConnection")));

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

            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseMvc(routers =>
            {
                routers.MapRoute("default", "{Controller=Home}/{Action=Index}/{id?}");

            });
        }
    }
}

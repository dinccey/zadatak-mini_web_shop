using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Repository;
using Microsoft.EntityFrameworkCore;
using Zadatak.MiniWebShop.Infrastructure.Domain;
using Zadatak.MiniWebShop.Repository.Proizvodi;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Proizvodi;
using Zadatak.MiniWebShop.Service.Narudzbe;
using Zadatak.MiniWebShop.Repository.Narudzbe;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });

            services.AddControllers();

            

            services.AddDbContext<MiniWebShopContext>((options) => options.UseSqlServer(Configuration.GetConnectionString("MiniWebShop")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProizvodRepository, ProizvodRepository>();
            services.AddTransient<IProizvodService, ProizvodService>();
            services.AddTransient<IKosaricaService, KosaricaService>();
            services.AddTransient<INarudzbaService, NarudzbaService>();
            services.AddTransient<INarudzbaRepository, NarudzbaRepository>();
            services.AddTransient<KosaricaDomainService, KosaricaDomainService>();
            services.AddTransient<ProizvodDomainService, ProizvodDomainService>();
            services.AddTransient<NarudzbaDomainService, NarudzbaDomainService>();
            services.AddSingleton<Kosarica, Kosarica>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zadatak.MiniWebShop.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zadatak.MiniWebShop.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

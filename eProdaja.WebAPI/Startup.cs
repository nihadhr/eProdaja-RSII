using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Model.Database;
using eProdaja.Model.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using eProdaja.WebAPI.Mappers;
using eProdaja.WebAPI.Filters;
using eProdaja.WebAPI.Services;

namespace eProdaja.Model
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
            services.AddControllers();
            services.AddMvc(x => x.Filters.Add<ErrorFilter>());
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();
            services.AddScoped<IProizvod, ProizvodService>();
            services.AddScoped<IKorisnik, KorisnikService>();
            services.AddScoped<IGeneric<Model.JediniceMjere, object>, GenericService<Model.JediniceMjere,Model.Database.JediniceMjere, object>>();
            services.AddScoped<IGeneric<Model.VrsteProizvoda,object>, GenericService<Model.VrsteProizvoda,Database.VrsteProizvoda,object>>();

            var connection = @"Server=.;Database=eProdaja;Trusted_Connection=True;";
            services.AddDbContext<eProdajaContext>(options => options.UseSqlServer(connection)); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

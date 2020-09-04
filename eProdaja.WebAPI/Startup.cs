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
using eProdaja.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using eProdaja.WebAPI.Security;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;


namespace eProdaja.Model
{
    //public class BasicAuthDocumentFilter : IDocumentFilter
    //{
    //    public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
    //    {
    //        var securityRequirements = new Dictionary<string, IEnumerable<string>>()
    //    {
    //        { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
    //    };

    //        swaggerDoc.Security = new[] { securityRequirements };
    //    }
    //}
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
            services.AddMvc((x => x.EnableEndpointRouting=false)).AddNewtonsoftJson();
            
            services.AddAutoMapper(typeof(Startup));
            //swagger 5.x.x 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eProdaja", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { 
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

            });
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            //ok


            services.AddScoped<IGeneric<Model.Proizvod,Requests.ProizvodSearchRequest>, ProizvodService>();
            services.AddScoped<IKorisnik, KorisnikService>();
            services.AddScoped<IGeneric<Model.JediniceMjere, object>, GenericService<Model.JediniceMjere,Model.Database.JediniceMjere, object>>();
            services.AddScoped<IGeneric<Model.VrsteProizvoda,object>, GenericService<Model.VrsteProizvoda,Database.VrsteProizvoda,object>>();
            services.AddScoped<ICRUD<Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>, ProizvodService>();
            services.AddScoped<IGeneric<Model.Uloge, object>, GenericService<Model.Uloge, Model.Database.Uloge, object>>();
            var connection = @"Server=NH;Database=eProdaja;Trusted_Connection=True;";

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

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseMvc();
        }
    }
}

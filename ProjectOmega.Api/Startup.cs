﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectOmega.DAL.Firebird;
using ProjectOmega.DAL.Firebird.Repositories;
using ProjectOmega.DAL.Firebird.Repositories.Interfaces;
using ProjectOmega.DAL.MsSql.Services;
using ProjectOmega.Repositories.ClientsRepository;
using ProjectOmega.Repositories.OrdersRepositories;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjectOmega.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IOrdersRepository, SqlOrdersRepository>();
            services.AddScoped<IBaseRepository<R3_CONTACTS>, BaseRepository<R3_CONTACTS>>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            
            var connection = @"Data Source = LP-JAREK\SQLEXPRESS; Initial Catalog = ProjectOmega; Integrated Security = SSPI;";
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "OmegaAPI", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OmegaAPI");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

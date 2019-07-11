using System;
using System.Reflection;
using AutoMapper;
using ESVS.Application.Catalogs.Commands.CreateCatalog;
using ESVS.Application.Catalogs.Queries.GetCatalog;
using ESVS.Application.Infrastructure;
using ESVS.Application.Infrastructure.AutoMapper;
using ESVS.Application.Interfaces;
using ESVS.Common;
using ESVS.Domain.Entities;
using ESVS.Infrastructure;
using ESVS.Persistence;
using ESVS.WebUi.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ESVS.WebUi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => 
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
              services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<IESVSDbContext, ESVSDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ESVSDatabase")));

            services.AddDbContext<ESVSDbContext>(options => options.UseSqlServer(
            Configuration.GetConnectionString("ESVSDatabase")));
            services.AddIdentity<User,IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ESVSDbContext>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCatalogCommandValidator>());
            services.AddSwaggerDocument();
            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });



            services.AddSpaStaticFiles(configuration =>
          {
              configuration.RootPath = "ClientApp/dist";
          });
            // Add MediatR
            services.AddMediatR(typeof(GetCatalogQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
    
            //app.UseCookiePolicy();
            //app.UseCors(builder => builder
            //   .AllowAnyOrigin()
            //   .AllowAnyMethod()
            //   .AllowAnyHeader()
            //   .AllowCredentials());
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
           {
               settings.Path = "/api";
           });
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //        spa.UseReactDevelopmentServer("start");
            //});
        }
    }
}

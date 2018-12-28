using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using DataAccess.DbImplementation;
using DataAccess.DbImplementation.Roles;
using DataAccess.DbImplementation.Users;
using DataAccess.Roles;
using DataAccess.Users;
using DB;
using Entities;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using License = System.ComponentModel.License;

/// <summary>
/// Slava ukraini, snizu primer raboti s bazoy
/// Cmock v pisu
/// </summary>

namespace ESVS
{
    public class Startup
    {
        //Здесь был Владислав и Кирилл
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpContextAccessor();
            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(Startup));
            RegisterQueriesAndCommands(services);
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ESVS",
                    Version = "v1",
                    Description = "ESVS",
                    TermsOfService = "None",

                });
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication(

            );
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void RegisterQueriesAndCommands(IServiceCollection services)
        {
            services
                .AddScoped<ICreateUserCommand, CreateUserCommand>()
                .AddScoped<ILogOffUserCommand, LogOffUserCommand>()
                .AddScoped<ILoginUserCommand, LoginUserCommand>()
                .AddScoped<IChangeUserPasswordCommand, ChangeUserPasswordCommand>()
                .AddScoped<IUpdateUserCommand, UpdateUserCommand>()
                .AddScoped<IUserQuery, UserQuery>()
                .AddScoped<IUsersListQuery, UsersListQuery>()
                .AddScoped<IDeleteUserCommand, DeleteUserCommand>()
                .AddScoped<IRoleQuery, RoleQuery>()
                .AddScoped<IRolesListQuery, RolesListQuery>()
                .AddScoped<IUpdateRoleCommand, UpdateRoleCommand>()
                .AddScoped<IAddRoleToUserCommand, AddRoleToUserCommand>()
                .AddScoped<IRemoveRoleFromUserCommand, RemoveRoleFromUserCommand>()
                .AddScoped<ICreateRoleCommand, CreateRoleCommand>()
                .AddScoped<IDeleteRoleCommand, DeleteRoleCommand>()
                .AddScoped<ICatalogsQuery, CatalogsQuery>()
                .AddScoped<IUpdateCatalogsCommand, UpdateCatalogsCommand>()
                .AddScoped<ICreateCatalogsCommand, CreateCatalogsCommand>()
                .AddScoped<IDeleteCatalogsCommand, DeleteCatalogsCommand>()
                .AddScoped<ICatalogsListQuery, CatalogsListQuery>();


        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Catalog;
using DataAccess.DbImplementation.Catalog;
using DataAccess.DbImplementation.Roles;
using DataAccess.DbImplementation.Users;
using DataAccess.DbImplementation.Field;
using DataAccess.DbImplementation.FieldValue;
using DataAccess.DbImplementation.General;
using DataAccess.Roles;
using DataAccess.Users;
using DataAccess.Field;
using DataAccess.FieldValue;
using DataAccess.General;
using DB;
using Entities;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddHttpContextAccessor();
            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(Startup));
            RegisterQueriesAndCommands(services);
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
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
                    TermsOfService = "None"

                });
            });

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
            app.UseAuthentication();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            
            app.UseSpaStaticFiles();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer("start");
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
                .AddScoped<ICatalogQuery, CatalogQuery>()
                .AddScoped<IUpdateCatalogCommand, UpdateCatalogCommand>()
                .AddScoped<ICreateCatalogCommand, CreateCatalogCommand>()
                .AddScoped<IDeleteCatalogCommand, DeleteCatalogCommand>()
                .AddScoped<ICatalogListQuery, CatalogListQuery>()
                .AddScoped<IFieldQuery, FieldQuery>()
                .AddScoped<IUpdateFieldCommand, UpdateFieldCommand>()
                .AddScoped<ICreateFieldCommand, CreateFieldCommand>()
                .AddScoped<IDeleteFieldCommand, DeleteFieldCommand>()
                .AddScoped<IFieldListQuery, FieldListQuery>()
                .AddScoped<IFieldValuesQuery, FieldValueQuery>()
                .AddScoped<IUpdateFieldValuesCommand, UpdateFieldValueCommand>()
                .AddScoped<ICreateFieldValuesCommand, CreateFieldValueCommand>()
                .AddScoped<IDeleteFieldValuesCommand, DeleteFieldValueCommand>()
                .AddScoped<IFieldValuesListQuery, FieldValueListQuery>()
                 .AddScoped<IGenerateDbFromKmiac, GenerateDbFromKmiac>()
                ;
        }
    }
}

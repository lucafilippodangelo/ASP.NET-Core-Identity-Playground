using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityTest.DbContexes;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using IdentityTest.Interfaces;
using IdentityTest.Services;
using IdentityTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityTest
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);


            //LD STEP002
            services.AddScoped<ICarData, SqlCarData>();

            services.AddDbContext<ProjectDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("LdConnectionString")));

            //LD STEP4
            //LD add the new context
            services.AddDbContext<ImplementIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LdConnectionString")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ImplementIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AddEditUser", policy => { policy.RequireClaim("Add User", "Add User"); policy.RequireClaim("Edit User", "Edit User"); });
                options.AddPolicy("DeleteUser", policy => policy.RequireClaim("Delete User", "Delete User"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //LD STEP3
            app.UseIdentity();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

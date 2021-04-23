using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlacovuCMS.Core.Identity;
using PlacovuCMS.Core.Utility;
using PlacovuCMS.Model;
using PlacovuCMS.Web.Data;
using PlacovuCMS.Web.Infrastructure;
using System;

namespace PlacovuCMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public AppConfig AppConfigOptions { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Identity
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.LogoutPath = "/Account/Logout";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            #endregion

            #region Database
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region AppConfig
            // Add our Config object so it can be injected
            services.Configure<AppConfig>(Configuration.GetSection("AppConfig"));
            AppConfigOptions = new AppConfig();
            Configuration.GetSection("AppConfig").Bind(AppConfigOptions);
            #endregion

            BootStrapper.Run(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var applyCache = AppConfigOptions.AllowCaching && (DateTime.Now > AppConfigOptions.ApplyCacheAfter);

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

            // redirect to www
            var options = new RewriteOptions();
            options.Rules.Add(new RedirectWwwRule());
            app.UseRewriter(options);
            //redirect to www

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            #region App Settiing
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".mp4"] = "video/mp4";
            provider.Mappings[".woff2"] = "font/woff2";
            #endregion

            /*Identity*/
            app.UseAuthentication();
            app.UseAuthorization();
            /*End*/

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = provider
            });

            if (applyCache)
            {
                app.UseResponseCaching();
            }

            app.UseResponseCompression();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.Use(async (context, next) =>
            {

                if (applyCache)
                {
                    context.Response.GetTypedHeaders().CacheControl =
                        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromDays(100)
                        };
                }
                else
                {
                    context.Response.GetTypedHeaders().CacheControl =
                        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                        {
                            NoCache = true,
                            NoStore = true,
                            Public = true,
                            MaxAge = TimeSpan.FromDays(-1)
                        };
                }
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.AccessControlAllowOrigin] =
                    new string[] { "*" };

                context.Response.Headers["X-Content-Type-Options"] = "nosniff";
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyBlogUrl",
                    pattern: "b/{name}",
                    defaults: new { controller = "Home", action = "MyBlog" });

                endpoints.MapControllerRoute(
                    name: "PagingPageOne",
                    pattern: "{controller}",
                    defaults: new { controller = "Home", action = "Index", id = 1 });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "{controller}/{id:int?}",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "MatchUrl",
                    pattern: "{name:required}",
                    defaults: new { controller = "Home", action = "Page" });

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

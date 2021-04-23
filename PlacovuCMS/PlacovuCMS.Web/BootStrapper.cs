using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlacovuCMS.Core.Extensions;
using PlacovuCMS.Core.Utility;
using PlacovuCMS.Repository.AutoMapperProfile;
using System;
using System.IO.Compression;
using System.Linq;

namespace PlacovuCMS.Web
{
    public class BootStrapper
    {
        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddRouting(options => options.LowercaseUrls = true);

                services.RegisterCustomRoute();

                // Add functionality to inject IOptions<T>
                services.AddOptions();

                services.AddRazorPages().AddRazorRuntimeCompilation();

                services.AddCors();

                #region MemoryCache
                //services.AddDistributedMemoryCache();
                //services.AddMemoryCache();
                #endregion

                //services.AddMvc(
                //   options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
                //);
                //call this in case you need aspnet-user-authtype/aspnet-user-identity
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                
                services.AddHsts(options =>
                {
                    options.Preload = true;
                    options.IncludeSubDomains = true;
                    options.MaxAge = TimeSpan.FromDays(60);
                });
                services.AddResponseCompression(options =>
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>();
                    //options.EnableForHttps = true;
                    options.MimeTypes =
                        ResponseCompressionDefaults.MimeTypes.Concat(
                            new[] { "text/html", "text/css", "application/javascript", "text/javascript", "font/woff2", "image/svg+xml", "image/jpeg", "image/jpg", "image/png", "application/x-msdownload", "application/x-msdownload" });
                });
                services.Configure<BrotliCompressionProviderOptions>(options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });
                services.Configure<GzipCompressionProviderOptions>(options =>
                {
                    options.Level = CompressionLevel.Fastest;
                });

                services.RegisterAutoMapper();

                services.RegisterAllTypes(typeof(PlacovuCMS.Manager.DependencyPlug).Assembly);
                services.RegisterAllTypes(typeof(PlacovuCMS.Repository.DependencyPlug).Assembly);

                services.RegisterDataTables();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

using CMS.App.Manager;
using CMS.App.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CMS.App
{
    public class BootStrapper
    {
        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                //Service AddScoped
                InitializeAddScoped(services);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static void InitializeAddScoped(IServiceCollection services)
        {
            try
            {
                services.AddScoped<IBlogManager, BlogManager>();
                services.AddScoped<IBlogRepository, BlogRepository>();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}

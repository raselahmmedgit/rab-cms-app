using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace PlacovuCMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4netConfig.Load(File.OpenRead("log4net.config"));
                var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                    typeof(Hierarchy));
                XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

                CreateWebHostBuilder(args).Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

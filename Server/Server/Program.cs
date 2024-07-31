
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Services;
using Shared.Statics;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {                    
                    SettingsLoad(config);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build().Run();
        }

        /// <summary>
        /// Метод устанавеливает настройки из <paramref name="confBuilder"/>
        /// </summary>
        /// <param name="confBuilder">Тип для построения конфигурации</param>
        public static void SettingsLoad(IConfigurationBuilder confBuilder)
        {
            IConfigurationRoot confRoot = confBuilder.Build();
            Settings.ConnectionString = confRoot.GetValue<string>("ConnectionStrings:MSSql")!;
        }
    }
}

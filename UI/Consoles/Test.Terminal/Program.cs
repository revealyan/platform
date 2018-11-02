using Common.Logger;
using Core;
using Core.Platforms;
using Core.Platforms.Configurations;
using System;
using System.Linq;

namespace Test.Terminal
{
    class Program
    {
        #region core
        private static IPlatform platform;
        private static PlatformConfiguration configuration;

        private static string configPath = @"platform.json";
        private static string conString = @"Server=192.168.0.102;Port=3306;Database=agroshop;Uid=revealyan;Password=carvayne2Qq";
        #endregion

        #region modules
        private static ILogger logger;
        #endregion

        static void Main(string[] args)
        {
            try
            {
                configuration = new FilePlatformConfiguration(configPath);
                platform = new BasePlatform(configuration);
                platform.Startup();
                logger = (ILogger)platform.GetModules().FirstOrDefault(x => x.GetInterfaceTypes().Contains(typeof(ILogger)));
                logger.LogDebug("Work it");
            }
            catch (Exception exc)
            {
                PrintError(exc.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void PrintError(string v)
        {
            var consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine();
            Console.ForegroundColor = consoleColor;
        }
    }
}

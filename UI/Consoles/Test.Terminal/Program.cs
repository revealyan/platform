using Common.Database.Interface;
using Common.Logger;
using Common.Logger.Interface;
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

        private static readonly string configPath = @"platform.json";
        #endregion

        #region modules
        private static IDatabase database;
        private static bool isWorked = false;
        #endregion

        static void Main(string[] args)
        {
            try
            {
                configuration = new FilePlatformConfiguration(configPath);
                platform = new BasePlatform(configuration);
                platform.Startup();
                database = (IDatabase)platform.GetModules().FirstOrDefault(x => x.GetInterfaceTypes().Contains(typeof(IDatabase)));

                using (var cmd = database.CreateCommand("SELECT * FROM PRODUCTS LIMIT 10"))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetValue<int>("id")} {reader.GetValue<string>("article")} {reader.GetValue<string>("name")} {reader.GetValue<decimal>("price")} {reader.GetValue<decimal>("count")}");
                        }
                    }
                }
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

        private static string ConsoleReadLine()
        {
            Console.Write(">>> ");
            return Console.ReadLine();
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

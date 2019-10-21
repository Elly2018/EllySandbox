using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EllySandboxWeb
{
    public class Program
    {
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        public static void Main(string[] args)
        {
            try
            {
                bool develop = JsonConvert.DeserializeObject<ApplicationInfo>(File.ReadAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Elly Sandbox", "setting", "Appinfo.json"))
                ).OpenConsole;
                ShowWindow(GetConsoleWindow(), develop ? SW_SHOW : SW_HIDE);
            }
            catch
            {

            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseWebRoot("bin");
                    webBuilder.UseStartup<Startup>();
                });

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}

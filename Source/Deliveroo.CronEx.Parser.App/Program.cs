using Microsoft.Extensions.DependencyInjection;
using System;

namespace Deliveroo.CronEx.Parser.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var services = Startup.AddApplicationServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<EntryPoint>().Run(args);
        }
    }
}

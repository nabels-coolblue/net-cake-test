using System;
using System.Collections.Generic;
using Serilog;
using SimpleInjector;
using Topshelf;
using Topshelf.SimpleInjector;

namespace WindowsServiceWithOwin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(configurator =>
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    .WriteTo.ColoredConsole()
                    .CreateLogger();
                
                configurator.UseSerilog();
                configurator.SetServiceName("Sample.WindowsServiceWithOwin");
                configurator.UseSimpleInjector(new Container());
                
                configurator.Service<SampleWindowsService>(s =>
                {
                    s.ConstructUsingSimpleInjector();
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                });
            });
        }
    }
}
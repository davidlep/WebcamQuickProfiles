using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using WebcamQuickProfiles.GUI;

namespace WebcamQuickProfiles;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var host = CreateHostBuilder().Build();

        Application.Run(host.Services.GetRequiredService<AppContext>());
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => 
            {
                services.AddTransient<AppContext>();
                services.AddSingleton<WebcamServices>();
                services.AddTransient<ConfigureForm>();
            });
    }
}
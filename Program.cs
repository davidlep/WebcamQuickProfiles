using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.GUI;
using WebcamQuickProfiles.Webcam;

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

        Task.Run(() => host.Services.GetService<WebcamMonitor>().MonitorWebRunning());


        Application.Run(host.Services.GetRequiredService<AppContext>());
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => 
            {
                services.AddTransient<AppContext>();
                services.AddSingleton<WebcamService>();
                services.AddTransient<ConfigureForm>();
                services.AddTransient<ProfileEditForm>();
                services.AddTransient<WebcamMonitor>();
            });
    }
}
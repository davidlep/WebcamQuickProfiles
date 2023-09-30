using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WebcamQuickProfiles.GUI;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles;

internal class AppContext : ApplicationContext
{
    private NotifyIcon trayIcon;
    private Container components = new Container();
    private WebcamService webcamService;

    private static IServiceProvider serviceProviderInstance;
    public static IDictionary<Type, Form> FormInstances { get; set; } = new Dictionary<Type, Form>();

    public AppContext(IServiceProvider serviceProvider, WebcamService webcamService)
    {
        serviceProviderInstance = serviceProvider;
        this.webcamService = webcamService;

        Init();
        
    }

    private void Init()
    {
        var contextMenu = new ContextMenuStrip();
        this.ConfigureTrayMenu(contextMenu);

        trayIcon = new NotifyIcon(components)
        {
            ContextMenuStrip = contextMenu,
            Icon = new System.Drawing.Icon("icon.ico"),
            Text = $"Webcam quick profiles",
            Visible = true,
        };
        
        webcamService.Init();

        //trayIcon.ShowBalloonTip(3000, "Test", "Body", ToolTipIcon.Info);

        //TEMP testing
        OpenForm<ConfigureForm>();
    }

    void ConfigureTrayMenu(ContextMenuStrip contextMenu)
    {
        var menuItemExit = new ToolStripMenuItem("Exit", null, (sender, e) =>
        {
            trayIcon.Visible = false;
            Application.Exit();
        });

        var menuItemSelectProfile = new ToolStripMenuItem("Select", null);

        //menuItemSelectProfile.DropDownItems.AddRange(new[] { menuItemWebcam, menuItemProfiles });

        //var menuItemEditProfiles = new ToolStripMenuItem("Edit", null, (sender, e) =>
        //{
        //    //var p = new Process();
        //    //p.StartInfo = new ProcessStartInfo(Settings.FileName)
        //    //{
        //    //    UseShellExecute = true
        //    //};
        //    //p.Start();
        //});

        var menuItemWebcamOptions = new ToolStripMenuItem("Webcam options", null, (sender, e) =>
        {
            Application.Restart();
        });

        var menuItemConfigure = new ToolStripMenuItem("Configure", null, (sender, e) =>
        {
            OpenForm<ConfigureForm>();
        });


        contextMenu.Items.AddRange(new[] { menuItemSelectProfile, menuItemConfigure, menuItemWebcamOptions, menuItemExit });
    }

    public static void OpenForm<T>() where T : Form
    {
        FormInstances.TryGetValue(typeof(T), out var formInstance);

        if (formInstance != null)
        {
            formInstance.BringToFront();
            return;
        }

        formInstance = serviceProviderInstance.GetService<T>();
        formInstance.FormClosed += (s, e) => FormInstances[typeof(T)] = null;
        FormInstances[typeof(T)] = formInstance;

        formInstance.Show();
    }
}

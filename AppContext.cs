using AForge.Video.DirectShow;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.AForge;
using WebcamQuickProfiles.GUI;

namespace WebcamQuickProfiles;

internal class AppContext : ApplicationContext
{
    private NotifyIcon trayIcon;
    private Container components = new Container();
    private WebcamServices webcamServices;

    private static IServiceProvider serviceProviderInstance;
    public static IDictionary<Type, Form> FormInstances { get; set; } = new Dictionary<Type, Form>();

    public AppContext(IServiceProvider serviceProvider, WebcamServices webcamServices)
    {
        serviceProviderInstance = serviceProvider;
        this.webcamServices = webcamServices;

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
        
        webcamServices.Init();

        //trayIcon.ShowBalloonTip(3000, "Test", "Body", ToolTipIcon.Info);
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

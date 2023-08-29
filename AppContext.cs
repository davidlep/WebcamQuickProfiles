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
    private readonly IServiceProvider serviceProvider;
    private WebcamServices webcamServices;

    public AppContext(IServiceProvider serviceProvider, WebcamServices webcamServices)
    {
        this.serviceProvider = serviceProvider;
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

        var menuItemNewProfile = new ToolStripMenuItem("New", null, (sender, e) =>
        {
            Application.Restart();
        });

        var menuItemConfigure = new ToolStripMenuItem("Configure", null, (sender, e) =>
        {
            var configureForm = serviceProvider.GetService<ConfigureForm>();
            configureForm.Show();
        });


        contextMenu.Items.AddRange(new[] { menuItemSelectProfile, menuItemConfigure, menuItemExit });
    }
}

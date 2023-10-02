using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration;
using WebcamQuickProfiles.GUI;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles;

internal class AppContext : ApplicationContext
{
    private NotifyIcon trayIcon;
    private Container components = new Container();
    private readonly WebcamService webcamService;
    private readonly ProfilesService profilesService;
    private static IServiceProvider serviceProviderInstance;
    public static IDictionary<Type, Form> FormInstances { get; set; } = new Dictionary<Type, Form>();

    public AppContext(
        IServiceProvider serviceProvider, 
        WebcamService webcamService, 
        ProfilesService profilesService)
    {
        serviceProviderInstance = serviceProvider;
        this.webcamService = webcamService;
        this.profilesService = profilesService;
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

        var menuItemSelectProfile = new ToolStripMenuItem("Profiles", null);

        menuItemSelectProfile.DropDownItems.AddRange(GetProfilesMenuItems().ToArray());

        var menuItemConfigure = new ToolStripMenuItem("Configure", null, (sender, e) =>
        {
            OpenForm<ConfigureForm>();
            //TODO on form close, update profile tool strip menu
        });


        contextMenu.Items.AddRange(new[] { menuItemSelectProfile, menuItemConfigure, menuItemExit });
    }

    private IEnumerable<ToolStripMenuItem> GetProfilesMenuItems()
    {
        var profiles = profilesService.GetAllProfileEntries();

        foreach (var profile in profiles)
        {
            yield return new ToolStripMenuItem(profile.Name, null, (sender, e) =>
            {
                
            });
        }
    }

    public static void OpenForm<T>(T formInstance = null) where T : Form
    {
        FormInstances.TryGetValue(typeof(T), out var existingFormInstance);

        if (existingFormInstance != null)
        {
            existingFormInstance.BringToFront();
            return;
        }

        if (formInstance is null)
        {
            formInstance = InstanciateForm<T>();
        }

        formInstance.FormClosed += (s, e) => FormInstances[typeof(T)] = null;
        FormInstances[typeof(T)] = formInstance;
        formInstance.ShowDialog();
    }

    public static T InstanciateForm<T>() where T : Form
    {
        return serviceProviderInstance.GetService<T>();
    }
}

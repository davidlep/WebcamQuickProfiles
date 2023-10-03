using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration.Profiles;
using WebcamQuickProfiles.Configuration.Settings;
using WebcamQuickProfiles.GUI;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles;

internal class AppContext : ApplicationContext
{
    private NotifyIcon trayIcon;
    private Container components = new Container();
    private readonly WebcamService webcamService;
    private readonly ProfilesService profilesService;
    private readonly FormsManager formsManager;
    private readonly SettingsService settingsService;

    public ToolStripMenuItem[] ProfileMenuItems { get; set; }

    public AppContext(
        WebcamService webcamService, 
        ProfilesService profilesService,
        FormsManager formsManager,
        SettingsService settingsService)
    {
        this.webcamService = webcamService;
        this.profilesService = profilesService;
        this.formsManager = formsManager;
        this.settingsService = settingsService;
        
        Init();
    }

    private void Init()
    {
        settingsService.LoadSettings();

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
    }

    void ConfigureTrayMenu(ContextMenuStrip contextMenu)
    {
        var menuItemExit = new ToolStripMenuItem("Exit", null, (sender, e) =>
        {
            trayIcon.Visible = false;
            Application.Exit();
        });

        var menuItemSelectProfile = new ToolStripMenuItem("Profiles", null);

        ProfileMenuItems = GetProfilesMenuItems().ToArray();

        menuItemSelectProfile.DropDownItems.AddRange(ProfileMenuItems);

        var menuItemConfigure = new ToolStripMenuItem("Configure", null, (sender, e) =>
        {
            formsManager.ShowForm<ConfigureForm>();
            //TODO on form close, update profile tool strip menu
        });


        contextMenu.Items.AddRange(new[] { menuItemSelectProfile, menuItemConfigure, menuItemExit });
    }

    private IEnumerable<ToolStripMenuItem> GetProfilesMenuItems()
    {
        var profiles = profilesService.GetAllProfileEntries();
        var settings = settingsService.GetSettings();

        foreach (var profile in profiles)
        {
            var menuItem = new ToolStripMenuItem(profile.Name, null, (sender, e) =>
            {
                var toolStripMenuItem = sender as ToolStripMenuItem;
                settingsService.UpdateCurrentProfileId(profile.Id);
                ResetCheckedMenuItemsUIState();
                toolStripMenuItem.Checked = true;
            });

            if (settings.CurrentProfileId == profile.Id)
            {
                menuItem.Checked = true;
            }

            yield return menuItem;
        }
    }

    private void ResetCheckedMenuItemsUIState()
    {
        foreach (var menuItem in ProfileMenuItems)
            menuItem.Checked = false;
    }
}

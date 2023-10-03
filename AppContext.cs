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

    public IDictionary<Guid, ToolStripMenuItem> ProfileMenuItemsById { get; set; }
    public ToolStripMenuItem MenuItemSelectProfile { get; set; }

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
        //TODO Extract in field var
        var menuItemExit = new ToolStripMenuItem("Exit", null, (sender, e) =>
        {
            //TODO Extract method
            trayIcon.Visible = false;
            Application.Exit();
        });

        this.MenuItemSelectProfile = new ToolStripMenuItem("Profiles", null);

        //TODO Extract in field var
        var menuItemConfigure = new ToolStripMenuItem("Configure", null, (sender, e) =>
        {
            //TODO Extract method
            formsManager.ShowForm<ConfigureForm>();
            RefreshProfileMenuItemsUIState();
        });
        
        contextMenu.Items.AddRange(new[] { MenuItemSelectProfile, menuItemConfigure, menuItemExit });

        RefreshProfileMenuItemsUIState();
    }

    private IDictionary<Guid, ToolStripMenuItem> GetProfilesMenuItems()
    {
        var profileMenuItemsById = new Dictionary<Guid, ToolStripMenuItem>();
        var profiles = profilesService.GetAllProfileEntries();
        var settings = settingsService.Settings;

        foreach (var profile in profiles)
        {
            var menuItem = new ToolStripMenuItem(profile.Name, null, (sender, e) =>
            {
                HandleProfileMenuItemClick(profile, sender as ToolStripMenuItem);
            });

            profileMenuItemsById.Add(profile.Id, menuItem);
        }

        return profileMenuItemsById;
    }

    private void HandleProfileMenuItemClick(ProfileEntry profile, ToolStripMenuItem menuItem)
    {
        webcamService.ApplyProfile(profile.Id);
        settingsService.UpdateCurrentProfileId(profile.Id);
        RefreshProfileMenuItemsUIState();
    }

    private void RefreshProfileMenuItemsUIState()
    {
        this.ProfileMenuItemsById = GetProfilesMenuItems();
        this.MenuItemSelectProfile.DropDownItems.Clear();
        this.MenuItemSelectProfile.DropDownItems.AddRange(ProfileMenuItemsById.Values.ToArray());
        
        var settings = settingsService.Settings;
        foreach (var profileMenuItem in ProfileMenuItemsById)
        {
            profileMenuItem.Value.Checked = settings.CurrentProfileId == profileMenuItem.Key;
        }
    }
}

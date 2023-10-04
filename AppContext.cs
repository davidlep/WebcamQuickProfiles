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
    public ToolStripMenuItem ProfileMenuItem { get; set; }
    public ToolStripMenuItem ConfigureMenuItem { get; set; }
    public ToolStripMenuItem ExitMenuItem { get; set; }

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
        webcamService.Init();

        var contextMenu = new ContextMenuStrip();

        ConfigureTrayIcon(contextMenu);
        ConfigureTrayMenu(contextMenu);        
    }

    void ConfigureTrayIcon(ContextMenuStrip contextMenu)
    {
        trayIcon = new NotifyIcon(components)
        {
            ContextMenuStrip = contextMenu,
            Icon = new System.Drawing.Icon("icon.ico"),
            Text = $"Webcam Quick Profiles",
            Visible = true,
        };

        trayIcon.DoubleClick += (s, e) => HandleConfigureAction();

        trayIcon.ShowBalloonTip(3000, "Webcam Quick Profiles", "Configure and select profiles from the tray icon.", ToolTipIcon.Info);
    }

    void ConfigureTrayMenu(ContextMenuStrip contextMenu)
    {
        this.ProfileMenuItem = new ToolStripMenuItem("Profiles", null);
        RefreshProfileMenuItemsUIState();

        this.ConfigureMenuItem = new ToolStripMenuItem("Configure", null, (sender, e) => HandleConfigureAction());
        this.ExitMenuItem = new ToolStripMenuItem("Exit", null, (sender, e) => HandleExitAction());

        contextMenu.Items.AddRange(new[]
        { 
            this.ProfileMenuItem, 
            this.ConfigureMenuItem, 
            this.ExitMenuItem
        });
    }

    private IDictionary<Guid, ToolStripMenuItem> GetProfilesMenuItems()
    {
        var profileMenuItemsById = new Dictionary<Guid, ToolStripMenuItem>();
        var profiles = profilesService.GetAllProfileEntries();
        var settings = settingsService.GetSettings();

        foreach (var profile in profiles)
        {
            var menuItem = new ToolStripMenuItem(profile.Name, null, (sender, e) =>
            {
                HandleProfileAction(profile);
            });

            profileMenuItemsById.Add(profile.Id, menuItem);
        }

        return profileMenuItemsById;
    }

    private void HandleExitAction()
    {
        trayIcon.Visible = false;
        Application.Exit();
    }

    private void HandleProfileAction(ProfileEntry profile)
    {
        webcamService.ApplyProfile(profile.Id);
        settingsService.UpdateCurrentProfileId(profile.Id);
        RefreshProfileMenuItemsUIState();
    }
    private void HandleConfigureAction()
    {
        formsManager.ShowForm<ConfigureForm>();
        RefreshProfileMenuItemsUIState();
    }

    private void RefreshProfileMenuItemsUIState()
    {
        this.ProfileMenuItemsById = GetProfilesMenuItems();

        this.ProfileMenuItem.DropDownItems.Clear();
        this.ProfileMenuItem.DropDownItems.AddRange(ProfileMenuItemsById.Values.ToArray());
        
        var settings = settingsService.GetSettings();
        foreach (var profileMenuItem in ProfileMenuItemsById)
        {
            profileMenuItem.Value.Checked = settings.CurrentProfileId == profileMenuItem.Key;
        }
    }
}

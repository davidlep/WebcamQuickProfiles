using Microsoft.Extensions.Caching.Memory;
using Octokit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration.Profiles;
using WebcamQuickProfiles.Configuration.Settings;

namespace WebcamQuickProfiles.GUI
{
    public partial class ConfigureForm : Form
    {
        private readonly ProfilesService profilesService;
        private readonly SettingsService settingsService;
        private readonly FormsManager formsManager;
        private readonly IMemoryCache memoryCache;

        private IList<ProfileEntry> ProfilesEntries;

        public ConfigureForm(
            ProfilesService profilesService,
            SettingsService settingsService,
            FormsManager formsManager,
            IMemoryCache memoryCache)
        {
            this.profilesService = profilesService;
            this.settingsService = settingsService;
            this.formsManager = formsManager;
            this.memoryCache = memoryCache;
            InitializeComponent();

            RefreshProfilesUIState();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_AddProfile_Click(object sender, EventArgs e)
        {
            var editform = formsManager.NewForm<ProfileEditForm>();
            editform.FormClosed += (s, e) => RefreshProfilesUIState();
            formsManager.ShowForm(editform);
        }

        private void RefreshProfilesUIState()
        {
            ProfilesEntries = profilesService.GetAllProfileEntries();

            LB_Profiles.Items.Clear();
            LB_Profiles.Items.AddRange(ProfilesEntries.Select(x => x.Name).ToArray());

            RefreshEditUIState();
        }

        private void BTN_EditProfile_Click(object sender, EventArgs e)
        {
            EditSelectedProfile();
        }

        private void LB_Profiles_Leave(object sender, EventArgs e)
        {
            RefreshEditUIState();
        }

        private void LB_Profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshEditUIState();
        }

        private void RefreshEditUIState()
        {
            BTN_EditProfile.Enabled = LB_Profiles.SelectedItem != null;
            BTN_DeleteProfile.Enabled = LB_Profiles.SelectedItem != null;
        }

        private void LB_Profiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSelectedProfile();
        }

        private void EditSelectedProfile()
        {
            var selectedIndex = LB_Profiles.SelectedIndex;

            if (selectedIndex == -1)
                return;

            var selectedProfileId = ProfilesEntries.ElementAt(selectedIndex).Id;
            var selectedProfile = this.profilesService.LoadProfile(selectedProfileId);

            var formInstance = formsManager.NewForm<ProfileEditForm>();
            formInstance.FormProfile = selectedProfile;
            formInstance.FormClosed += (s, e) => RefreshProfilesUIState();
            formsManager.ShowForm(formInstance);
        }

        private void BTN_DeleteProfile_Click(object sender, EventArgs e)
        {
            var selectedIndex = LB_Profiles.SelectedIndex;

            if (selectedIndex == -1)
                return;

            var selectedProfileId = ProfilesEntries.ElementAt(selectedIndex).Id;
            var selectedProfile = this.profilesService.LoadProfile(selectedProfileId);

            var confirmResult = MessageBox.Show(
                $"Are you sure to delete the profile {selectedProfile.Name}",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No)
                return;

            this.profilesService.DeleteProfile(selectedProfileId);

            RefreshProfilesUIState();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            var settings = settingsService.GetSettings();
            CB_AutomaticRestore.Checked = settings.AutomaticProfile;

            Task.Run(SetVersionLabel);
        }

        private void CB_AutomaticRestore_CheckedChanged(object sender, EventArgs e)
        {
            settingsService.UpdateAutomaticProfile(CB_AutomaticRestore.Checked);
        }

        private async Task SetVersionLabel()
        {
            if (await IsNewReleaseAvailable())
            {
                var latestRelease = await GetLatestRelease();
                var boldFont = new Font(LB_Version.Font, FontStyle.Bold);
                LB_Version.Font = boldFont;
                LB_Version.Text = GetCurrentVersion() + " Click to download new version";
                LB_Version.Click += (sender, e) => LB_Version_Click(latestRelease);

                return;
            }

            LB_Version.Text = GetCurrentVersion();
        }

        private void LB_Version_Click(Release latestRelease)
        {
            Process.Start(latestRelease.Url);
        }

        private async Task<bool> IsNewReleaseAvailable()
        {
            var release = await GetLatestRelease();

            if (release is null)
                return false;

            return 
                release.TagName == GetCurrentVersion() && 
                !release.Prerelease;
        }

        private string GetCurrentVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private async Task<Release> GetLatestRelease()
        {
            if (memoryCache.TryGetValue("LatestRelease", out Release latestRelease))
            {
                return latestRelease;
            }

            var client = new GitHubClient(new ProductHeaderValue("WebcamQuickProfiles"));

            try
            {
                latestRelease = await client.Repository.Release.GetLatest("davidlep", "WebcamQuickProfiles");
            }
            catch (NotFoundException)
            {
                latestRelease = null;
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
            };

            memoryCache.Set("LatestRelease", latestRelease, cacheEntryOptions);

            return latestRelease;
        }
    }
}

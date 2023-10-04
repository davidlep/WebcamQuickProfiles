using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration.Profiles;
using WebcamQuickProfiles.Configuration.Settings;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles.GUI
{
    public partial class ConfigureForm : Form
    {
        private readonly WebcamService webcamService;
        private readonly ProfilesService profilesService;
        private readonly SettingsService settingsService;
        private readonly FormsManager formsManager;
        private IList<ProfileEntry> ProfilesEntries;

        public ConfigureForm(
            WebcamService webcamService,
            ProfilesService profilesService,
            SettingsService settingsService,
            FormsManager formsManager)
        {
            this.webcamService = webcamService;
            this.profilesService = profilesService;
            this.settingsService = settingsService;
            this.formsManager = formsManager;
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

            LB_Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CB_AutomaticRestore.Checked = settings.AutomaticProfile;
        }

        private void CB_AutomaticRestore_CheckedChanged(object sender, EventArgs e)
        {
            settingsService.UpdateAutomaticProfile(CB_AutomaticRestore.Checked);
        }
    }
}

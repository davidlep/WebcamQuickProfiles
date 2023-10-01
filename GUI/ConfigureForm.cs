using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration;
using WebcamQuickProfiles.Profiles;
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles.GUI
{
    public partial class ConfigureForm : Form
    {
        private readonly WebcamService webcamService;
        private readonly ProfilesService profilesService;
        private IList<ProfileEntry> ProfilesEntries;

        public ConfigureForm(
            WebcamService webcamService,
            ProfilesService profilesService)
        {
            this.webcamService = webcamService;
            this.profilesService = profilesService;

            InitializeComponent();

            RefreshProfiles();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_AddProfile_Click(object sender, EventArgs e)
        {
            var formInstance = AppContext.InstanciateForm<ProfileEditForm>();
            formInstance.FormClosed += (s, e) => RefreshProfiles();
            AppContext.OpenForm(formInstance);
        }

        private void RefreshProfiles()
        {
            ProfilesEntries = profilesService.GetAllProfileEntries();

            LB_Profiles.Items.Clear();
            LB_Profiles.Items.AddRange(ProfilesEntries.Select(x => x.Name).ToArray());

            UpdateGUI();
        }

        private void BTN_EditProfile_Click(object sender, EventArgs e)
        {
            EditSelectedProfile();
        }

        private void LB_Profiles_Leave(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        private void LB_Profiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGUI();
        }

        private void UpdateGUI()
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
            var selectedProfileId = ProfilesEntries.ElementAt(LB_Profiles.SelectedIndex).Id;
            var selectedProfile = this.profilesService.LoadProfile(selectedProfileId);

            var formInstance = AppContext.InstanciateForm<ProfileEditForm>();
            formInstance.FormProfile = selectedProfile;
            formInstance.FormClosed += (s, e) => RefreshProfiles();
            AppContext.OpenForm(formInstance);
        }
    }
}

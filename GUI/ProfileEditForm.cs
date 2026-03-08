using AForge.Video;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamQuickProfiles.Configuration.Profiles;
using WebcamQuickProfiles.Webcam;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebcamQuickProfiles.GUI
{
    public partial class ProfileEditForm : Form
    {
        private readonly WebcamService webcamService;
        private readonly ProfilesService profilesService;
        public Profile FormProfile { get; set; }

        public ProfileEditForm(
            WebcamService webcamService,
            ProfilesService profilesService)
        {
            this.webcamService = webcamService;
            this.profilesService = profilesService;
            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_EditSettings_Click(object sender, EventArgs e)
        {
            var selectedWebcam = CB_Webcams.SelectedItem?.ToString();
            if (selectedWebcam is null || !this.webcamService.VideoSources.ContainsKey(selectedWebcam))
                return;

            var videoSource = this.webcamService.VideoSources[selectedWebcam];
            if (FormProfile is not null)
            {
                this.webcamService.ApplyWebcamSettings(videoSource, FormProfile.WebcamSettings);
            }

            videoSource.DisplayPropertyPage(IntPtr.Zero);
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_ProfileName.Text))
            {
                MessageBox.Show(
                $"Profile name cannot be empty",
                "Validation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                return;
            }

            var selectedVideoSourceId = CB_Webcams.SelectedItem?.ToString();
            if (selectedVideoSourceId is null || !this.webcamService.VideoSources.ContainsKey(selectedVideoSourceId))
            {
                MessageBox.Show(
                    "Selected webcam is not available",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (FormProfile is null)
            {
                FormProfile = new Profile
                {
                    Id = Guid.NewGuid()
                };
            }

            //Name
            FormProfile.Name = TB_ProfileName.Text;

            //Video source (webcam)
            FormProfile.VideoSourceId = selectedVideoSourceId;

            //Settings
            var videoSource = this.webcamService.VideoSources[FormProfile.VideoSourceId];
            FormProfile.WebcamSettings = this.webcamService.GetWebcamSettings(videoSource);

            profilesService.SaveProfile(FormProfile);

            this.Close();
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            webcamService.RefreshDevices();
            CB_Webcams.Items.AddRange(webcamService.VideoSources.Keys.ToArray());

            if (FormProfile is null)
            {
                if (CB_Webcams.Items.Count > 0)
                    CB_Webcams.SelectedItem = CB_Webcams.Items[0];
                return;
            }

            LoadFormWithProfile();
        }

        private void LoadFormWithProfile()
        {
            CB_Webcams.SelectedIndex = CB_Webcams.FindStringExact(FormProfile.VideoSourceId);
            TB_ProfileName.Text = FormProfile.Name;
        }

        private void BTN_OpenCameraApp_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("microsoft.windows.camera:")
            {
                UseShellExecute = true,
                Verb = "open"
            };

            Process.Start(ps);
        }
    }
}

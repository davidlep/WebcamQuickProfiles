using AForge.Video;
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
            var videoSource = this.webcamService.VideoSources[CB_Webcams.SelectedItem.ToString()];
            if (FormProfile is not null)
            {
                this.webcamService.ApplyWebcamSettings(videoSource, FormProfile.WebcamSettings);
            }

            videoSource.DisplayPropertyPage(IntPtr.Zero);
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
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
            var selectedVideoSourceId = CB_Webcams.SelectedItem.ToString();
            FormProfile.VideoSourceId = selectedVideoSourceId;

            //Settings
            var videoSource = this.webcamService.VideoSources[FormProfile.VideoSourceId];
            FormProfile.WebcamSettings = this.webcamService.GetWebcamSettings(videoSource);

            profilesService.SaveProfile(FormProfile);

            this.Close();
        }

        private void ProfileEditForm_Load(object sender, EventArgs e)
        {
            CB_Webcams.Items.AddRange(webcamService.VideoSources.Keys.ToArray());

            if (FormProfile is null)
            {
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
    }
}

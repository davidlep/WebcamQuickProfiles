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
using WebcamQuickProfiles.Webcam;

namespace WebcamQuickProfiles.GUI
{
    public partial class ProfileEditForm : Form
    {
        private WebcamService webcamService;

        public ProfileEditForm(WebcamService webcamService)
        {
            this.webcamService = webcamService;

            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_EditSettings_Click(object sender, EventArgs e)
        {
            var currentVideoSource = this.webcamService.GetCurrentVideoSource();
            currentVideoSource.DisplayPropertyPage(IntPtr.Zero);
        }

        private void BTN_Save_Click(object sender, EventArgs e)
        {
            webcamService.SavedSettingsTEMP = webcamService.GetWebcamSettings(webcamService.GetCurrentVideoSource());
        }
    }
}

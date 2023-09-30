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
    public partial class ConfigureForm : Form
    {
        private readonly WebcamService webcamService;

        public ConfigureForm(WebcamService webcamService)
        {
            this.webcamService = webcamService;

            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            CB_Webcams.Items.AddRange(webcamService.VideoSources.Keys.ToArray());
            CB_Webcams.SelectedItem = CB_Webcams.Items[0];
        }

        private void BTN_AddProfile_Click(object sender, EventArgs e)
        {
            AppContext.OpenForm<ProfileEditForm>();
        }

        private void CB_Webcams_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.webcamService.CurrentVideoSourceId = CB_Webcams.SelectedItem.ToString();
        }
    }
}

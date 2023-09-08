using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebcamQuickProfiles.GUI
{
    public partial class ConfigureForm : Form
    {
        private readonly WebcamServices webcamServices;

        public ConfigureForm(WebcamServices webcamServices)
        {
            this.webcamServices = webcamServices;

            InitializeComponent();
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            CB_Webcams.Items.AddRange(webcamServices.VideoSources.Keys.ToArray());
        }

        private void BTN_AddProfile_Click(object sender, EventArgs e)
        {

        }
    }
}

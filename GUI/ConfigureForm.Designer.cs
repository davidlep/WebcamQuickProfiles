namespace WebcamQuickProfiles.GUI
{
    partial class ConfigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new System.Windows.Forms.GroupBox();
            CB_Webcams = new System.Windows.Forms.ComboBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            BTN_EditProfile = new System.Windows.Forms.Button();
            BTN_DeleteProfile = new System.Windows.Forms.Button();
            BTN_AddProfile = new System.Windows.Forms.Button();
            LB_Profiles = new System.Windows.Forms.ListBox();
            BTN_Close = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(CB_Webcams);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(458, 70);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Webcam";
            // 
            // CB_Webcams
            // 
            CB_Webcams.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CB_Webcams.FormattingEnabled = true;
            CB_Webcams.Location = new System.Drawing.Point(6, 26);
            CB_Webcams.Name = "CB_Webcams";
            CB_Webcams.Size = new System.Drawing.Size(437, 28);
            CB_Webcams.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(BTN_EditProfile);
            groupBox2.Controls.Add(BTN_DeleteProfile);
            groupBox2.Controls.Add(BTN_AddProfile);
            groupBox2.Controls.Add(LB_Profiles);
            groupBox2.Location = new System.Drawing.Point(12, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(458, 368);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Profiles";
            // 
            // BTN_EditProfile
            // 
            BTN_EditProfile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BTN_EditProfile.Location = new System.Drawing.Point(374, 68);
            BTN_EditProfile.Name = "BTN_EditProfile";
            BTN_EditProfile.Size = new System.Drawing.Size(78, 36);
            BTN_EditProfile.TabIndex = 3;
            BTN_EditProfile.Text = "✏️";
            BTN_EditProfile.UseVisualStyleBackColor = true;
            // 
            // BTN_DeleteProfile
            // 
            BTN_DeleteProfile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BTN_DeleteProfile.Location = new System.Drawing.Point(374, 110);
            BTN_DeleteProfile.Name = "BTN_DeleteProfile";
            BTN_DeleteProfile.Size = new System.Drawing.Size(78, 36);
            BTN_DeleteProfile.TabIndex = 2;
            BTN_DeleteProfile.Text = "🗑️";
            BTN_DeleteProfile.UseVisualStyleBackColor = true;
            // 
            // BTN_AddProfile
            // 
            BTN_AddProfile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BTN_AddProfile.Location = new System.Drawing.Point(374, 26);
            BTN_AddProfile.Name = "BTN_AddProfile";
            BTN_AddProfile.Size = new System.Drawing.Size(78, 36);
            BTN_AddProfile.TabIndex = 1;
            BTN_AddProfile.Text = "➕";
            BTN_AddProfile.UseVisualStyleBackColor = true;
            // 
            // LB_Profiles
            // 
            LB_Profiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LB_Profiles.FormattingEnabled = true;
            LB_Profiles.ItemHeight = 20;
            LB_Profiles.Location = new System.Drawing.Point(6, 26);
            LB_Profiles.Name = "LB_Profiles";
            LB_Profiles.Size = new System.Drawing.Size(359, 324);
            LB_Profiles.TabIndex = 0;
            // 
            // BTN_Close
            // 
            BTN_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BTN_Close.Location = new System.Drawing.Point(376, 472);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new System.Drawing.Size(94, 29);
            BTN_Close.TabIndex = 2;
            BTN_Close.Text = "Close";
            BTN_Close.UseVisualStyleBackColor = true;
            BTN_Close.Click += BTN_Close_Click;
            // 
            // ConfigureForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(482, 513);
            Controls.Add(BTN_Close);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            MinimumSize = new System.Drawing.Size(500, 560);
            Name = "ConfigureForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Configure webcam profiles";
            Load += ConfigureForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTN_AddProfile;
        private System.Windows.Forms.ListBox LB_Profiles;
        private System.Windows.Forms.ComboBox CB_Webcams;
        private System.Windows.Forms.Button BTN_EditProfile;
        private System.Windows.Forms.Button BTN_DeleteProfile;
        private System.Windows.Forms.Button BTN_Close;
    }
}
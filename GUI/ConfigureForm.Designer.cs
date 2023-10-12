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
            groupBox2 = new System.Windows.Forms.GroupBox();
            CB_AutomaticRestore = new System.Windows.Forms.CheckBox();
            BTN_EditProfile = new System.Windows.Forms.Button();
            BTN_DeleteProfile = new System.Windows.Forms.Button();
            BTN_AddProfile = new System.Windows.Forms.Button();
            LB_Profiles = new System.Windows.Forms.ListBox();
            BTN_Close = new System.Windows.Forms.Button();
            LB_Version = new System.Windows.Forms.Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(CB_AutomaticRestore);
            groupBox2.Controls.Add(BTN_EditProfile);
            groupBox2.Controls.Add(BTN_DeleteProfile);
            groupBox2.Controls.Add(BTN_AddProfile);
            groupBox2.Controls.Add(LB_Profiles);
            groupBox2.Location = new System.Drawing.Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(458, 423);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Profiles";
            // 
            // CB_AutomaticRestore
            // 
            CB_AutomaticRestore.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CB_AutomaticRestore.AutoSize = true;
            CB_AutomaticRestore.Location = new System.Drawing.Point(6, 393);
            CB_AutomaticRestore.Name = "CB_AutomaticRestore";
            CB_AutomaticRestore.Size = new System.Drawing.Size(410, 24);
            CB_AutomaticRestore.TabIndex = 4;
            CB_AutomaticRestore.Text = "Automatically apply active profile when webcam is in use";
            CB_AutomaticRestore.UseVisualStyleBackColor = true;
            CB_AutomaticRestore.CheckedChanged += CB_AutomaticRestore_CheckedChanged;
            // 
            // BTN_EditProfile
            // 
            BTN_EditProfile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BTN_EditProfile.Location = new System.Drawing.Point(374, 68);
            BTN_EditProfile.Name = "BTN_EditProfile";
            BTN_EditProfile.Size = new System.Drawing.Size(78, 36);
            BTN_EditProfile.TabIndex = 2;
            BTN_EditProfile.Text = "✏️";
            BTN_EditProfile.UseVisualStyleBackColor = true;
            BTN_EditProfile.Click += BTN_EditProfile_Click;
            // 
            // BTN_DeleteProfile
            // 
            BTN_DeleteProfile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            BTN_DeleteProfile.Location = new System.Drawing.Point(374, 110);
            BTN_DeleteProfile.Name = "BTN_DeleteProfile";
            BTN_DeleteProfile.Size = new System.Drawing.Size(78, 36);
            BTN_DeleteProfile.TabIndex = 3;
            BTN_DeleteProfile.Text = "🗑️";
            BTN_DeleteProfile.UseVisualStyleBackColor = true;
            BTN_DeleteProfile.Click += BTN_DeleteProfile_Click;
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
            BTN_AddProfile.Click += BTN_AddProfile_Click;
            // 
            // LB_Profiles
            // 
            LB_Profiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LB_Profiles.FormattingEnabled = true;
            LB_Profiles.ItemHeight = 20;
            LB_Profiles.Location = new System.Drawing.Point(6, 26);
            LB_Profiles.Name = "LB_Profiles";
            LB_Profiles.Size = new System.Drawing.Size(359, 344);
            LB_Profiles.TabIndex = 0;
            LB_Profiles.SelectedIndexChanged += LB_Profiles_SelectedIndexChanged;
            LB_Profiles.Leave += LB_Profiles_Leave;
            LB_Profiles.MouseDoubleClick += LB_Profiles_MouseDoubleClick;
            // 
            // BTN_Close
            // 
            BTN_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BTN_Close.Location = new System.Drawing.Point(376, 472);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new System.Drawing.Size(94, 29);
            BTN_Close.TabIndex = 5;
            BTN_Close.Text = "Close";
            BTN_Close.UseVisualStyleBackColor = true;
            BTN_Close.Click += BTN_Close_Click;
            // 
            // LB_Version
            // 
            LB_Version.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            LB_Version.AutoSize = true;
            LB_Version.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LB_Version.Location = new System.Drawing.Point(12, 487);
            LB_Version.Name = "LB_Version";
            LB_Version.Size = new System.Drawing.Size(59, 17);
            LB_Version.TabIndex = 3;
            LB_Version.Text = "[Version]";
            // 
            // ConfigureForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(482, 513);
            Controls.Add(LB_Version);
            Controls.Add(BTN_Close);
            Controls.Add(groupBox2);
            MinimumSize = new System.Drawing.Size(500, 560);
            Name = "ConfigureForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "W";
            Load += ConfigureForm_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTN_AddProfile;
        private System.Windows.Forms.ListBox LB_Profiles;
        private System.Windows.Forms.Button BTN_EditProfile;
        private System.Windows.Forms.Button BTN_DeleteProfile;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Label LB_Version;
        private System.Windows.Forms.CheckBox CB_AutomaticRestore;
    }
}
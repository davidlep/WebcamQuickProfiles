namespace WebcamQuickProfiles.GUI
{
    partial class ProfileEditForm
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
            TB_ProfileName = new System.Windows.Forms.TextBox();
            BTN_EditSettings = new System.Windows.Forms.Button();
            BTN_Close = new System.Windows.Forms.Button();
            BTN_Save = new System.Windows.Forms.Button();
            GB_Webcam = new System.Windows.Forms.GroupBox();
            CB_Webcams = new System.Windows.Forms.ComboBox();
            GB_ProfileName = new System.Windows.Forms.GroupBox();
            GB_Webcam.SuspendLayout();
            GB_ProfileName.SuspendLayout();
            SuspendLayout();
            // 
            // TB_ProfileName
            // 
            TB_ProfileName.Location = new System.Drawing.Point(6, 26);
            TB_ProfileName.Name = "TB_ProfileName";
            TB_ProfileName.Size = new System.Drawing.Size(471, 27);
            TB_ProfileName.TabIndex = 0;
            // 
            // BTN_EditSettings
            // 
            BTN_EditSettings.Location = new System.Drawing.Point(12, 154);
            BTN_EditSettings.Name = "BTN_EditSettings";
            BTN_EditSettings.Size = new System.Drawing.Size(489, 49);
            BTN_EditSettings.TabIndex = 1;
            BTN_EditSettings.Text = "Edit webcam settings";
            BTN_EditSettings.UseVisualStyleBackColor = true;
            BTN_EditSettings.Click += BTN_EditSettings_Click;
            // 
            // BTN_Close
            // 
            BTN_Close.Location = new System.Drawing.Point(401, 228);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new System.Drawing.Size(94, 29);
            BTN_Close.TabIndex = 3;
            BTN_Close.Text = "Cancel";
            BTN_Close.UseVisualStyleBackColor = true;
            BTN_Close.Click += BTN_Close_Click;
            // 
            // BTN_Save
            // 
            BTN_Save.Location = new System.Drawing.Point(192, 228);
            BTN_Save.Name = "BTN_Save";
            BTN_Save.Size = new System.Drawing.Size(203, 29);
            BTN_Save.TabIndex = 4;
            BTN_Save.Text = "Save with current settings";
            BTN_Save.UseVisualStyleBackColor = true;
            BTN_Save.Click += BTN_Save_Click;
            // 
            // GB_Webcam
            // 
            GB_Webcam.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            GB_Webcam.Controls.Add(CB_Webcams);
            GB_Webcam.Location = new System.Drawing.Point(12, 78);
            GB_Webcam.Name = "GB_Webcam";
            GB_Webcam.Size = new System.Drawing.Size(489, 70);
            GB_Webcam.TabIndex = 6;
            GB_Webcam.TabStop = false;
            GB_Webcam.Text = "Webcam";
            // 
            // CB_Webcams
            // 
            CB_Webcams.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CB_Webcams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Webcams.FormattingEnabled = true;
            CB_Webcams.Location = new System.Drawing.Point(6, 26);
            CB_Webcams.Name = "CB_Webcams";
            CB_Webcams.Size = new System.Drawing.Size(471, 28);
            CB_Webcams.TabIndex = 0;
            // 
            // GB_ProfileName
            // 
            GB_ProfileName.Controls.Add(TB_ProfileName);
            GB_ProfileName.Location = new System.Drawing.Point(12, 7);
            GB_ProfileName.Name = "GB_ProfileName";
            GB_ProfileName.Size = new System.Drawing.Size(483, 65);
            GB_ProfileName.TabIndex = 7;
            GB_ProfileName.TabStop = false;
            GB_ProfileName.Text = "Profile name";
            // 
            // ProfileEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(507, 269);
            Controls.Add(GB_ProfileName);
            Controls.Add(GB_Webcam);
            Controls.Add(BTN_Save);
            Controls.Add(BTN_Close);
            Controls.Add(BTN_EditSettings);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProfileEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Profile Edit";
            Load += ProfileEditForm_Load;
            GB_Webcam.ResumeLayout(false);
            GB_ProfileName.ResumeLayout(false);
            GB_ProfileName.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox TB_ProfileName;
        private System.Windows.Forms.Button BTN_EditSettings;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.GroupBox GB_Webcam;
        private System.Windows.Forms.ComboBox CB_Webcams;
        private System.Windows.Forms.GroupBox GB_ProfileName;
    }
}
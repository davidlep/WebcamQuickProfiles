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
            SuspendLayout();
            // 
            // TB_ProfileName
            // 
            TB_ProfileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TB_ProfileName.Location = new System.Drawing.Point(12, 12);
            TB_ProfileName.Name = "TB_ProfileName";
            TB_ProfileName.Size = new System.Drawing.Size(483, 34);
            TB_ProfileName.TabIndex = 0;
            TB_ProfileName.Text = "Profile name";
            // 
            // BTN_EditSettings
            // 
            BTN_EditSettings.Location = new System.Drawing.Point(12, 52);
            BTN_EditSettings.Name = "BTN_EditSettings";
            BTN_EditSettings.Size = new System.Drawing.Size(483, 49);
            BTN_EditSettings.TabIndex = 1;
            BTN_EditSettings.Text = "Edit settings";
            BTN_EditSettings.UseVisualStyleBackColor = true;
            // 
            // BTN_Close
            // 
            BTN_Close.Location = new System.Drawing.Point(401, 124);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new System.Drawing.Size(94, 29);
            BTN_Close.TabIndex = 3;
            BTN_Close.Text = "Close";
            BTN_Close.UseVisualStyleBackColor = true;
            // 
            // ProfileEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(507, 165);
            Controls.Add(BTN_Close);
            Controls.Add(BTN_EditSettings);
            Controls.Add(TB_ProfileName);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "ProfileEditForm";
            Text = "ProfileEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox TB_ProfileName;
        private System.Windows.Forms.Button BTN_EditSettings;
        private System.Windows.Forms.Button BTN_Close;
    }
}
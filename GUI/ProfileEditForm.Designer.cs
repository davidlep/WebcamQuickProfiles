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
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // TB_ProfileName
            // 
            TB_ProfileName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TB_ProfileName.Location = new System.Drawing.Point(114, 12);
            TB_ProfileName.Name = "TB_ProfileName";
            TB_ProfileName.Size = new System.Drawing.Size(381, 34);
            TB_ProfileName.TabIndex = 0;
            // 
            // BTN_EditSettings
            // 
            BTN_EditSettings.Location = new System.Drawing.Point(12, 52);
            BTN_EditSettings.Name = "BTN_EditSettings";
            BTN_EditSettings.Size = new System.Drawing.Size(483, 49);
            BTN_EditSettings.TabIndex = 1;
            BTN_EditSettings.Text = "Configure webcam profile 🎦";
            BTN_EditSettings.UseVisualStyleBackColor = true;
            BTN_EditSettings.Click += BTN_EditSettings_Click;
            // 
            // BTN_Close
            // 
            BTN_Close.Location = new System.Drawing.Point(401, 124);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new System.Drawing.Size(94, 29);
            BTN_Close.TabIndex = 3;
            BTN_Close.Text = "Cancel";
            BTN_Close.UseVisualStyleBackColor = true;
            BTN_Close.Click += BTN_Close_Click;
            // 
            // BTN_Save
            // 
            BTN_Save.Location = new System.Drawing.Point(301, 124);
            BTN_Save.Name = "BTN_Save";
            BTN_Save.Size = new System.Drawing.Size(94, 29);
            BTN_Save.TabIndex = 4;
            BTN_Save.Text = "Save";
            BTN_Save.UseVisualStyleBackColor = true;
            BTN_Save.Click += BTN_Save_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 22);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 20);
            label1.TabIndex = 5;
            label1.Text = "Profile name:";
            // 
            // ProfileEditForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(507, 165);
            Controls.Add(label1);
            Controls.Add(BTN_Save);
            Controls.Add(BTN_Close);
            Controls.Add(BTN_EditSettings);
            Controls.Add(TB_ProfileName);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ProfileEditForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Profile Edit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox TB_ProfileName;
        private System.Windows.Forms.Button BTN_EditSettings;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Label label1;
    }
}
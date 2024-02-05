namespace NEA2.Save_Handling
{
    partial class SaveFileNameInput
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
            this.FileNameInputText = new System.Windows.Forms.TextBox();
            this.BTN_SubmitSaveFileName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileNameInputText
            // 
            this.FileNameInputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.FileNameInputText.Location = new System.Drawing.Point(90, 90);
            this.FileNameInputText.MaxLength = 32;
            this.FileNameInputText.Name = "FileNameInputText";
            this.FileNameInputText.Size = new System.Drawing.Size(374, 53);
            this.FileNameInputText.TabIndex = 0;
            this.FileNameInputText.TextChanged += new System.EventHandler(this.On_InputTextChange);
            // 
            // BTN_SubmitSaveFileName
            // 
            this.BTN_SubmitSaveFileName.Enabled = false;
            this.BTN_SubmitSaveFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BTN_SubmitSaveFileName.Location = new System.Drawing.Point(199, 217);
            this.BTN_SubmitSaveFileName.Name = "BTN_SubmitSaveFileName";
            this.BTN_SubmitSaveFileName.Size = new System.Drawing.Size(135, 34);
            this.BTN_SubmitSaveFileName.TabIndex = 1;
            this.BTN_SubmitSaveFileName.Text = "Submit / Load";
            this.BTN_SubmitSaveFileName.UseVisualStyleBackColor = true;
            this.BTN_SubmitSaveFileName.Click += new System.EventHandler(this.BTN_SubmitSaveFileName_Click);
            // 
            // SaveFileNameInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 280);
            this.Controls.Add(this.BTN_SubmitSaveFileName);
            this.Controls.Add(this.FileNameInputText);
            this.Name = "SaveFileNameInput";
            this.Text = "SaveFileNameInput";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileNameInputText;
        private System.Windows.Forms.Button BTN_SubmitSaveFileName;
    }
}
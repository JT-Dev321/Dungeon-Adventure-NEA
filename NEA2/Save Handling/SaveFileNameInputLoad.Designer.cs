namespace NEA2.Save_Handling
{
    partial class SaveFileNameInputLoad
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
            this.BTN_SubmitSaveFileName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_SubmitSaveFileName
            // 
            this.BTN_SubmitSaveFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.BTN_SubmitSaveFileName.Location = new System.Drawing.Point(247, 255);
            this.BTN_SubmitSaveFileName.Name = "BTN_SubmitSaveFileName";
            this.BTN_SubmitSaveFileName.Size = new System.Drawing.Size(147, 34);
            this.BTN_SubmitSaveFileName.TabIndex = 2;
            this.BTN_SubmitSaveFileName.Text = "Submit / Load";
            this.BTN_SubmitSaveFileName.UseVisualStyleBackColor = true;
            this.BTN_SubmitSaveFileName.Click += new System.EventHandler(this.BTN_SubmitSaveFileName_Click);
            // 
            // SaveFileNameInputLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 348);
            this.Controls.Add(this.BTN_SubmitSaveFileName);
            this.Name = "SaveFileNameInputLoad";
            this.Text = "SaveFileNameInputLoad";
            this.Load += new System.EventHandler(this.SFNI_OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_SubmitSaveFileName;
    }
}
namespace NEA2
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.BTN_Start = new System.Windows.Forms.Button();
            this.BTN_LoadSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Start
            // 
            this.BTN_Start.AutoSize = true;
            this.BTN_Start.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.BTN_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BTN_Start.Location = new System.Drawing.Point(563, 444);
            this.BTN_Start.Name = "BTN_Start";
            this.BTN_Start.Size = new System.Drawing.Size(229, 66);
            this.BTN_Start.TabIndex = 0;
            this.BTN_Start.Text = "New Game";
            this.BTN_Start.UseVisualStyleBackColor = false;
            this.BTN_Start.Click += new System.EventHandler(this.BTN_NewGame_Click);
            // 
            // BTN_LoadSave
            // 
            this.BTN_LoadSave.AutoSize = true;
            this.BTN_LoadSave.BackColor = System.Drawing.Color.Transparent;
            this.BTN_LoadSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_LoadSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BTN_LoadSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BTN_LoadSave.Location = new System.Drawing.Point(620, 516);
            this.BTN_LoadSave.Name = "BTN_LoadSave";
            this.BTN_LoadSave.Size = new System.Drawing.Size(120, 35);
            this.BTN_LoadSave.TabIndex = 1;
            this.BTN_LoadSave.Text = "Load Save";
            this.BTN_LoadSave.UseVisualStyleBackColor = false;
            this.BTN_LoadSave.Click += new System.EventHandler(this.BTN_LoadSave_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.BTN_LoadSave);
            this.Controls.Add(this.BTN_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Start;
        private System.Windows.Forms.Button BTN_LoadSave;
    }
}
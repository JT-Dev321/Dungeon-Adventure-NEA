namespace NEA2
{
    partial class DungeonForm
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
            this.ViewMap = new System.Windows.Forms.Button();
            this.BTN_GoBack = new System.Windows.Forms.Button();
            this.GeneralInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ViewMap
            // 
            this.ViewMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ViewMap.Location = new System.Drawing.Point(1586, 12);
            this.ViewMap.Name = "ViewMap";
            this.ViewMap.Size = new System.Drawing.Size(100, 100);
            this.ViewMap.TabIndex = 3;
            this.ViewMap.Text = "View Map";
            this.ViewMap.UseVisualStyleBackColor = true;
            this.ViewMap.Click += new System.EventHandler(this.ViewMap_Click);
            // 
            // BTN_GoBack
            // 
            this.BTN_GoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_GoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BTN_GoBack.Location = new System.Drawing.Point(1692, 12);
            this.BTN_GoBack.Name = "BTN_GoBack";
            this.BTN_GoBack.Size = new System.Drawing.Size(100, 100);
            this.BTN_GoBack.TabIndex = 4;
            this.BTN_GoBack.Text = "Retreat";
            this.BTN_GoBack.UseVisualStyleBackColor = true;
            this.BTN_GoBack.Click += new System.EventHandler(this.BTN_GoBack_Click);
            // 
            // GeneralInfoLabel
            // 
            this.GeneralInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GeneralInfoLabel.AutoSize = true;
            this.GeneralInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.GeneralInfoLabel.Location = new System.Drawing.Point(910, 12);
            this.GeneralInfoLabel.Name = "GeneralInfoLabel";
            this.GeneralInfoLabel.Size = new System.Drawing.Size(0, 46);
            this.GeneralInfoLabel.TabIndex = 10;
            this.GeneralInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DungeonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1804, 961);
            this.Controls.Add(this.GeneralInfoLabel);
            this.Controls.Add(this.BTN_GoBack);
            this.Controls.Add(this.ViewMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DungeonForm";
            this.Text = "Dungeon";
            this.Load += new System.EventHandler(this.Dungeon1Form_Load);
            this.Shown += new System.EventHandler(this.DungeonForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button ViewMap;
        public System.Windows.Forms.Button BTN_GoBack;
        public System.Windows.Forms.Label GeneralInfoLabel;
        public System.Windows.Forms.Label TurnInfoLabel;
    }
}
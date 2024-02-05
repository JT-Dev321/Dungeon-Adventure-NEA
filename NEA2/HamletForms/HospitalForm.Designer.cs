namespace NEA2
{
    partial class HospitalForm
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
            this.SelectHero_CMB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HealButton = new System.Windows.Forms.Button();
            this.CurrentGoldLBL = new System.Windows.Forms.Label();
            this.SelectedHeroHealthLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectHero_CMB
            // 
            this.SelectHero_CMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SelectHero_CMB.FormattingEnabled = true;
            this.SelectHero_CMB.Location = new System.Drawing.Point(279, 154);
            this.SelectHero_CMB.Name = "SelectHero_CMB";
            this.SelectHero_CMB.Size = new System.Drawing.Size(203, 33);
            this.SelectHero_CMB.TabIndex = 0;
            this.SelectHero_CMB.SelectedIndexChanged += new System.EventHandler(this.HeroCMBBox_SelectChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.label1.Location = new System.Drawing.Point(129, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Hero To Heal";
            // 
            // HealButton
            // 
            this.HealButton.Location = new System.Drawing.Point(297, 242);
            this.HealButton.Name = "HealButton";
            this.HealButton.Size = new System.Drawing.Size(170, 40);
            this.HealButton.TabIndex = 2;
            this.HealButton.Text = "Heal (X)";
            this.HealButton.UseVisualStyleBackColor = true;
            this.HealButton.Click += new System.EventHandler(this.HealButton_Click);
            // 
            // CurrentGoldLBL
            // 
            this.CurrentGoldLBL.AutoSize = true;
            this.CurrentGoldLBL.Location = new System.Drawing.Point(13, 336);
            this.CurrentGoldLBL.Name = "CurrentGoldLBL";
            this.CurrentGoldLBL.Size = new System.Drawing.Size(0, 13);
            this.CurrentGoldLBL.TabIndex = 3;
            // 
            // SelectedHeroHealthLBL
            // 
            this.SelectedHeroHealthLBL.AutoSize = true;
            this.SelectedHeroHealthLBL.Location = new System.Drawing.Point(367, 190);
            this.SelectedHeroHealthLBL.Name = "SelectedHeroHealthLBL";
            this.SelectedHeroHealthLBL.Size = new System.Drawing.Size(0, 13);
            this.SelectedHeroHealthLBL.TabIndex = 4;
            // 
            // HospitalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.SelectedHeroHealthLBL);
            this.Controls.Add(this.CurrentGoldLBL);
            this.Controls.Add(this.HealButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectHero_CMB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HospitalForm";
            this.Text = "HospitalForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.HospitalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectHero_CMB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HealButton;
        private System.Windows.Forms.Label CurrentGoldLBL;
        private System.Windows.Forms.Label SelectedHeroHealthLBL;
    }
}
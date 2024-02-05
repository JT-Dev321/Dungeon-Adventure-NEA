namespace NEA2
{
    partial class BarracksForm
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SelectHero_CMB = new System.Windows.Forms.ComboBox();
            this.CurrentGoldLBL = new System.Windows.Forms.Label();
            this.CritLabel = new System.Windows.Forms.Label();
            this.ArmourLabel = new System.Windows.Forms.Label();
            this.DodgeLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.HPLabel = new System.Windows.Forms.Label();
            this.ManaLabel = new System.Windows.Forms.Label();
            this.ArrowLabel2 = new System.Windows.Forms.Label();
            this.ArrowLabel1 = new System.Windows.Forms.Label();
            this.ArrowLabel6 = new System.Windows.Forms.Label();
            this.ArrowLabel5 = new System.Windows.Forms.Label();
            this.ArrowLabel4 = new System.Windows.Forms.Label();
            this.ArrowLabel3 = new System.Windows.Forms.Label();
            this.ManaLabelAfter = new System.Windows.Forms.Label();
            this.HPLabelAfter = new System.Windows.Forms.Label();
            this.SpeedLabelAfter = new System.Windows.Forms.Label();
            this.DodgeLabelAfter = new System.Windows.Forms.Label();
            this.ArmourLabelAfter = new System.Windows.Forms.Label();
            this.CritLabelAfter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(443, 280);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(170, 40);
            this.ConfirmButton.TabIndex = 7;
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.TitleLabel.Location = new System.Drawing.Point(365, 64);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(309, 63);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Select Hero";
            // 
            // SelectHero_CMB
            // 
            this.SelectHero_CMB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.SelectHero_CMB.FormattingEnabled = true;
            this.SelectHero_CMB.Location = new System.Drawing.Point(437, 202);
            this.SelectHero_CMB.Name = "SelectHero_CMB";
            this.SelectHero_CMB.Size = new System.Drawing.Size(181, 28);
            this.SelectHero_CMB.TabIndex = 5;
            this.SelectHero_CMB.SelectedIndexChanged += new System.EventHandler(this.HeroCMBBox_SelectChange);
            // 
            // CurrentGoldLBL
            // 
            this.CurrentGoldLBL.AutoSize = true;
            this.CurrentGoldLBL.Location = new System.Drawing.Point(12, 428);
            this.CurrentGoldLBL.Name = "CurrentGoldLBL";
            this.CurrentGoldLBL.Size = new System.Drawing.Size(0, 13);
            this.CurrentGoldLBL.TabIndex = 8;
            // 
            // CritLabel
            // 
            this.CritLabel.AutoSize = true;
            this.CritLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CritLabel.Location = new System.Drawing.Point(12, 163);
            this.CritLabel.Name = "CritLabel";
            this.CritLabel.Size = new System.Drawing.Size(31, 18);
            this.CritLabel.TabIndex = 9;
            this.CritLabel.Text = "Crit";
            // 
            // ArmourLabel
            // 
            this.ArmourLabel.AutoSize = true;
            this.ArmourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArmourLabel.Location = new System.Drawing.Point(12, 181);
            this.ArmourLabel.Name = "ArmourLabel";
            this.ArmourLabel.Size = new System.Drawing.Size(57, 18);
            this.ArmourLabel.TabIndex = 10;
            this.ArmourLabel.Text = "Armour";
            // 
            // DodgeLabel
            // 
            this.DodgeLabel.AutoSize = true;
            this.DodgeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DodgeLabel.Location = new System.Drawing.Point(12, 199);
            this.DodgeLabel.Name = "DodgeLabel";
            this.DodgeLabel.Size = new System.Drawing.Size(52, 18);
            this.DodgeLabel.TabIndex = 11;
            this.DodgeLabel.Text = "Dodge";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SpeedLabel.Location = new System.Drawing.Point(12, 217);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(50, 18);
            this.SpeedLabel.TabIndex = 12;
            this.SpeedLabel.Text = "Speed";
            // 
            // HPLabel
            // 
            this.HPLabel.AutoSize = true;
            this.HPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.HPLabel.Location = new System.Drawing.Point(12, 127);
            this.HPLabel.Name = "HPLabel";
            this.HPLabel.Size = new System.Drawing.Size(29, 18);
            this.HPLabel.TabIndex = 13;
            this.HPLabel.Text = "HP";
            // 
            // ManaLabel
            // 
            this.ManaLabel.AutoSize = true;
            this.ManaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ManaLabel.Location = new System.Drawing.Point(12, 145);
            this.ManaLabel.Name = "ManaLabel";
            this.ManaLabel.Size = new System.Drawing.Size(45, 18);
            this.ManaLabel.TabIndex = 14;
            this.ManaLabel.Text = "Mana";
            // 
            // ArrowLabel2
            // 
            this.ArrowLabel2.AutoSize = true;
            this.ArrowLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel2.Location = new System.Drawing.Point(123, 145);
            this.ArrowLabel2.Name = "ArrowLabel2";
            this.ArrowLabel2.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel2.TabIndex = 20;
            this.ArrowLabel2.Text = "-->";
            // 
            // ArrowLabel1
            // 
            this.ArrowLabel1.AutoSize = true;
            this.ArrowLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel1.Location = new System.Drawing.Point(123, 127);
            this.ArrowLabel1.Name = "ArrowLabel1";
            this.ArrowLabel1.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel1.TabIndex = 19;
            this.ArrowLabel1.Text = "-->";
            // 
            // ArrowLabel6
            // 
            this.ArrowLabel6.AutoSize = true;
            this.ArrowLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel6.Location = new System.Drawing.Point(123, 217);
            this.ArrowLabel6.Name = "ArrowLabel6";
            this.ArrowLabel6.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel6.TabIndex = 18;
            this.ArrowLabel6.Text = "-->";
            // 
            // ArrowLabel5
            // 
            this.ArrowLabel5.AutoSize = true;
            this.ArrowLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel5.Location = new System.Drawing.Point(123, 199);
            this.ArrowLabel5.Name = "ArrowLabel5";
            this.ArrowLabel5.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel5.TabIndex = 17;
            this.ArrowLabel5.Text = "-->";
            // 
            // ArrowLabel4
            // 
            this.ArrowLabel4.AutoSize = true;
            this.ArrowLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel4.Location = new System.Drawing.Point(123, 181);
            this.ArrowLabel4.Name = "ArrowLabel4";
            this.ArrowLabel4.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel4.TabIndex = 16;
            this.ArrowLabel4.Text = "-->";
            // 
            // ArrowLabel3
            // 
            this.ArrowLabel3.AutoSize = true;
            this.ArrowLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArrowLabel3.Location = new System.Drawing.Point(123, 163);
            this.ArrowLabel3.Name = "ArrowLabel3";
            this.ArrowLabel3.Size = new System.Drawing.Size(27, 18);
            this.ArrowLabel3.TabIndex = 15;
            this.ArrowLabel3.Text = "-->";
            // 
            // ManaLabelAfter
            // 
            this.ManaLabelAfter.AutoSize = true;
            this.ManaLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ManaLabelAfter.Location = new System.Drawing.Point(152, 145);
            this.ManaLabelAfter.Name = "ManaLabelAfter";
            this.ManaLabelAfter.Size = new System.Drawing.Size(45, 18);
            this.ManaLabelAfter.TabIndex = 26;
            this.ManaLabelAfter.Text = "Mana";
            // 
            // HPLabelAfter
            // 
            this.HPLabelAfter.AutoSize = true;
            this.HPLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.HPLabelAfter.Location = new System.Drawing.Point(152, 127);
            this.HPLabelAfter.Name = "HPLabelAfter";
            this.HPLabelAfter.Size = new System.Drawing.Size(29, 18);
            this.HPLabelAfter.TabIndex = 25;
            this.HPLabelAfter.Text = "HP";
            // 
            // SpeedLabelAfter
            // 
            this.SpeedLabelAfter.AutoSize = true;
            this.SpeedLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SpeedLabelAfter.Location = new System.Drawing.Point(152, 217);
            this.SpeedLabelAfter.Name = "SpeedLabelAfter";
            this.SpeedLabelAfter.Size = new System.Drawing.Size(50, 18);
            this.SpeedLabelAfter.TabIndex = 24;
            this.SpeedLabelAfter.Text = "Speed";
            // 
            // DodgeLabelAfter
            // 
            this.DodgeLabelAfter.AutoSize = true;
            this.DodgeLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DodgeLabelAfter.Location = new System.Drawing.Point(152, 199);
            this.DodgeLabelAfter.Name = "DodgeLabelAfter";
            this.DodgeLabelAfter.Size = new System.Drawing.Size(52, 18);
            this.DodgeLabelAfter.TabIndex = 23;
            this.DodgeLabelAfter.Text = "Dodge";
            // 
            // ArmourLabelAfter
            // 
            this.ArmourLabelAfter.AutoSize = true;
            this.ArmourLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ArmourLabelAfter.Location = new System.Drawing.Point(152, 181);
            this.ArmourLabelAfter.Name = "ArmourLabelAfter";
            this.ArmourLabelAfter.Size = new System.Drawing.Size(57, 18);
            this.ArmourLabelAfter.TabIndex = 22;
            this.ArmourLabelAfter.Text = "Armour";
            // 
            // CritLabelAfter
            // 
            this.CritLabelAfter.AutoSize = true;
            this.CritLabelAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CritLabelAfter.Location = new System.Drawing.Point(152, 163);
            this.CritLabelAfter.Name = "CritLabelAfter";
            this.CritLabelAfter.Size = new System.Drawing.Size(31, 18);
            this.CritLabelAfter.TabIndex = 21;
            this.CritLabelAfter.Text = "Crit";
            // 
            // BarracksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ManaLabelAfter);
            this.Controls.Add(this.HPLabelAfter);
            this.Controls.Add(this.SpeedLabelAfter);
            this.Controls.Add(this.DodgeLabelAfter);
            this.Controls.Add(this.ArmourLabelAfter);
            this.Controls.Add(this.CritLabelAfter);
            this.Controls.Add(this.ArrowLabel2);
            this.Controls.Add(this.ArrowLabel1);
            this.Controls.Add(this.ArrowLabel6);
            this.Controls.Add(this.ArrowLabel5);
            this.Controls.Add(this.ArrowLabel4);
            this.Controls.Add(this.ArrowLabel3);
            this.Controls.Add(this.ManaLabel);
            this.Controls.Add(this.HPLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.DodgeLabel);
            this.Controls.Add(this.ArmourLabel);
            this.Controls.Add(this.CritLabel);
            this.Controls.Add(this.CurrentGoldLBL);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.SelectHero_CMB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BarracksForm";
            this.Text = "Barracks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.BarracksForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ComboBox SelectHero_CMB;
        private System.Windows.Forms.Label CurrentGoldLBL;
        private System.Windows.Forms.Label CritLabel;
        private System.Windows.Forms.Label ArmourLabel;
        private System.Windows.Forms.Label DodgeLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label HPLabel;
        private System.Windows.Forms.Label ManaLabel;
        private System.Windows.Forms.Label ArrowLabel2;
        private System.Windows.Forms.Label ArrowLabel1;
        private System.Windows.Forms.Label ArrowLabel6;
        private System.Windows.Forms.Label ArrowLabel5;
        private System.Windows.Forms.Label ArrowLabel4;
        private System.Windows.Forms.Label ArrowLabel3;
        private System.Windows.Forms.Label ManaLabelAfter;
        private System.Windows.Forms.Label HPLabelAfter;
        private System.Windows.Forms.Label SpeedLabelAfter;
        private System.Windows.Forms.Label DodgeLabelAfter;
        private System.Windows.Forms.Label ArmourLabelAfter;
        private System.Windows.Forms.Label CritLabelAfter;
    }
}
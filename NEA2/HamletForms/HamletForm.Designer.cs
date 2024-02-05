namespace NEA2
{
    partial class HamletForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HamletForm));
            this.BTN_hamlet_stagecoach = new System.Windows.Forms.Button();
            this.BTN_hamlet_blacksmith = new System.Windows.Forms.Button();
            this.BTN_hamlet_hospital = new System.Windows.Forms.Button();
            this.BTN_hamlet_tradermarket = new System.Windows.Forms.Button();
            this.btn_hamlet_ready = new System.Windows.Forms.Button();
            this.TestingButton = new System.Windows.Forms.Button();
            this.BTN_SaveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_hamlet_stagecoach
            // 
            this.BTN_hamlet_stagecoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BTN_hamlet_stagecoach.Location = new System.Drawing.Point(175, 493);
            this.BTN_hamlet_stagecoach.Name = "BTN_hamlet_stagecoach";
            this.BTN_hamlet_stagecoach.Size = new System.Drawing.Size(102, 62);
            this.BTN_hamlet_stagecoach.TabIndex = 0;
            this.BTN_hamlet_stagecoach.Text = "Stagecoach";
            this.BTN_hamlet_stagecoach.UseVisualStyleBackColor = true;
            this.BTN_hamlet_stagecoach.Click += new System.EventHandler(this.BTN_hamlet_stagecoach_Click);
            // 
            // BTN_hamlet_blacksmith
            // 
            this.BTN_hamlet_blacksmith.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BTN_hamlet_blacksmith.Location = new System.Drawing.Point(792, 468);
            this.BTN_hamlet_blacksmith.Name = "BTN_hamlet_blacksmith";
            this.BTN_hamlet_blacksmith.Size = new System.Drawing.Size(102, 62);
            this.BTN_hamlet_blacksmith.TabIndex = 1;
            this.BTN_hamlet_blacksmith.Text = "Barracks";
            this.BTN_hamlet_blacksmith.UseVisualStyleBackColor = true;
            this.BTN_hamlet_blacksmith.Click += new System.EventHandler(this.BTN_hamlet_blacksmith_Click);
            // 
            // BTN_hamlet_hospital
            // 
            this.BTN_hamlet_hospital.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BTN_hamlet_hospital.Location = new System.Drawing.Point(426, 308);
            this.BTN_hamlet_hospital.Name = "BTN_hamlet_hospital";
            this.BTN_hamlet_hospital.Size = new System.Drawing.Size(102, 62);
            this.BTN_hamlet_hospital.TabIndex = 2;
            this.BTN_hamlet_hospital.Text = "Hospital";
            this.BTN_hamlet_hospital.UseVisualStyleBackColor = true;
            this.BTN_hamlet_hospital.Click += new System.EventHandler(this.BTN_hamlet_hospital_Click);
            // 
            // BTN_hamlet_tradermarket
            // 
            this.BTN_hamlet_tradermarket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BTN_hamlet_tradermarket.Location = new System.Drawing.Point(617, 510);
            this.BTN_hamlet_tradermarket.Name = "BTN_hamlet_tradermarket";
            this.BTN_hamlet_tradermarket.Size = new System.Drawing.Size(102, 62);
            this.BTN_hamlet_tradermarket.TabIndex = 3;
            this.BTN_hamlet_tradermarket.Text = "Wagon";
            this.BTN_hamlet_tradermarket.UseVisualStyleBackColor = true;
            this.BTN_hamlet_tradermarket.Click += new System.EventHandler(this.BTN_hamlet_tradermarket_Click);
            // 
            // btn_hamlet_ready
            // 
            this.btn_hamlet_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btn_hamlet_ready.Location = new System.Drawing.Point(951, 597);
            this.btn_hamlet_ready.Name = "btn_hamlet_ready";
            this.btn_hamlet_ready.Size = new System.Drawing.Size(145, 62);
            this.btn_hamlet_ready.TabIndex = 4;
            this.btn_hamlet_ready.Text = "Ready >>";
            this.btn_hamlet_ready.UseVisualStyleBackColor = true;
            this.btn_hamlet_ready.Click += new System.EventHandler(this.btn_hamlet_ready_Click);
            // 
            // TestingButton
            // 
            this.TestingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TestingButton.Location = new System.Drawing.Point(12, 12);
            this.TestingButton.Name = "TestingButton";
            this.TestingButton.Size = new System.Drawing.Size(102, 62);
            this.TestingButton.TabIndex = 5;
            this.TestingButton.Text = "Customise Dungeons";
            this.TestingButton.UseVisualStyleBackColor = true;
            this.TestingButton.Click += new System.EventHandler(this.CustomDungeon_BTN);
            // 
            // BTN_SaveGame
            // 
            this.BTN_SaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BTN_SaveGame.Location = new System.Drawing.Point(120, 12);
            this.BTN_SaveGame.Name = "BTN_SaveGame";
            this.BTN_SaveGame.Size = new System.Drawing.Size(102, 62);
            this.BTN_SaveGame.TabIndex = 6;
            this.BTN_SaveGame.Text = "Save Game";
            this.BTN_SaveGame.UseVisualStyleBackColor = true;
            this.BTN_SaveGame.Click += new System.EventHandler(this.BTN_SaveGame_Click);
            // 
            // HamletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NEA2.Properties.Resources.TownImg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 671);
            this.Controls.Add(this.BTN_SaveGame);
            this.Controls.Add(this.TestingButton);
            this.Controls.Add(this.btn_hamlet_ready);
            this.Controls.Add(this.BTN_hamlet_tradermarket);
            this.Controls.Add(this.BTN_hamlet_hospital);
            this.Controls.Add(this.BTN_hamlet_blacksmith);
            this.Controls.Add(this.BTN_hamlet_stagecoach);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HamletForm";
            this.Text = "Hamlet";
            this.Load += new System.EventHandler(this.HamletForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_hamlet_stagecoach;
        private System.Windows.Forms.Button BTN_hamlet_blacksmith;
        private System.Windows.Forms.Button BTN_hamlet_hospital;
        private System.Windows.Forms.Button BTN_hamlet_tradermarket;
        private System.Windows.Forms.Button btn_hamlet_ready;
        private System.Windows.Forms.Button TestingButton;
        private System.Windows.Forms.Button BTN_SaveGame;
    }
}


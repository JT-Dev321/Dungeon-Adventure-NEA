namespace NEA2
{
    partial class EstateMapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstateMapForm));
            this.BTN_estate_dungeon1 = new System.Windows.Forms.Button();
            this.BTN_estate_dungeon2 = new System.Windows.Forms.Button();
            this.BTN_estate_dungeon3 = new System.Windows.Forms.Button();
            this.BTN_estate_dungeon4 = new System.Windows.Forms.Button();
            this.BTN_estate_dungeon5 = new System.Windows.Forms.Button();
            this.BTN_estate_tohamlet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_estate_dungeon1
            // 
            this.BTN_estate_dungeon1.Location = new System.Drawing.Point(400, 477);
            this.BTN_estate_dungeon1.Name = "BTN_estate_dungeon1";
            this.BTN_estate_dungeon1.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_dungeon1.TabIndex = 0;
            this.BTN_estate_dungeon1.Text = "button1";
            this.BTN_estate_dungeon1.UseVisualStyleBackColor = true;
            this.BTN_estate_dungeon1.Click += new System.EventHandler(this.BTN_estate_dungeon1_Click);
            // 
            // BTN_estate_dungeon2
            // 
            this.BTN_estate_dungeon2.Location = new System.Drawing.Point(489, 316);
            this.BTN_estate_dungeon2.Name = "BTN_estate_dungeon2";
            this.BTN_estate_dungeon2.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_dungeon2.TabIndex = 1;
            this.BTN_estate_dungeon2.Text = "button2";
            this.BTN_estate_dungeon2.UseVisualStyleBackColor = true;
            this.BTN_estate_dungeon2.Click += new System.EventHandler(this.BTN_estate_dungeon2_Click);
            // 
            // BTN_estate_dungeon3
            // 
            this.BTN_estate_dungeon3.Location = new System.Drawing.Point(350, 304);
            this.BTN_estate_dungeon3.Name = "BTN_estate_dungeon3";
            this.BTN_estate_dungeon3.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_dungeon3.TabIndex = 2;
            this.BTN_estate_dungeon3.Text = "button3";
            this.BTN_estate_dungeon3.UseVisualStyleBackColor = true;
            this.BTN_estate_dungeon3.Click += new System.EventHandler(this.BTN_estate_dungeon3_Click);
            // 
            // BTN_estate_dungeon4
            // 
            this.BTN_estate_dungeon4.Location = new System.Drawing.Point(613, 229);
            this.BTN_estate_dungeon4.Name = "BTN_estate_dungeon4";
            this.BTN_estate_dungeon4.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_dungeon4.TabIndex = 3;
            this.BTN_estate_dungeon4.Text = "button4";
            this.BTN_estate_dungeon4.UseVisualStyleBackColor = true;
            this.BTN_estate_dungeon4.Click += new System.EventHandler(this.BTN_estate_dungeon4_Click);
            // 
            // BTN_estate_dungeon5
            // 
            this.BTN_estate_dungeon5.Location = new System.Drawing.Point(704, 162);
            this.BTN_estate_dungeon5.Name = "BTN_estate_dungeon5";
            this.BTN_estate_dungeon5.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_dungeon5.TabIndex = 4;
            this.BTN_estate_dungeon5.Text = "button5";
            this.BTN_estate_dungeon5.UseVisualStyleBackColor = true;
            this.BTN_estate_dungeon5.Click += new System.EventHandler(this.BTN_estate_dungeon5_Click);
            // 
            // BTN_estate_tohamlet
            // 
            this.BTN_estate_tohamlet.Location = new System.Drawing.Point(741, 546);
            this.BTN_estate_tohamlet.Name = "BTN_estate_tohamlet";
            this.BTN_estate_tohamlet.Size = new System.Drawing.Size(75, 49);
            this.BTN_estate_tohamlet.TabIndex = 5;
            this.BTN_estate_tohamlet.Text = "<< Hamlet";
            this.BTN_estate_tohamlet.UseVisualStyleBackColor = true;
            this.BTN_estate_tohamlet.Click += new System.EventHandler(this.BTN_estate_tohamlet_Click);
            // 
            // EstateMapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1053, 681);
            this.Controls.Add(this.BTN_estate_tohamlet);
            this.Controls.Add(this.BTN_estate_dungeon5);
            this.Controls.Add(this.BTN_estate_dungeon4);
            this.Controls.Add(this.BTN_estate_dungeon3);
            this.Controls.Add(this.BTN_estate_dungeon2);
            this.Controls.Add(this.BTN_estate_dungeon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EstateMapForm";
            this.Text = "EstateMapForm";
            this.Load += new System.EventHandler(this.EstateMapForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_estate_dungeon1;
        private System.Windows.Forms.Button BTN_estate_dungeon2;
        private System.Windows.Forms.Button BTN_estate_dungeon3;
        private System.Windows.Forms.Button BTN_estate_dungeon4;
        private System.Windows.Forms.Button BTN_estate_dungeon5;
        private System.Windows.Forms.Button BTN_estate_tohamlet;
    }
}
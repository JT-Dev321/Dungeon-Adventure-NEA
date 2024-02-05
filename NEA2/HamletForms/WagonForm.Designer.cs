namespace NEA2.HamletForms
{
    partial class WagonForm
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
            this.CMB_AllySlot1 = new System.Windows.Forms.ComboBox();
            this.CMB_AllySlot2 = new System.Windows.Forms.ComboBox();
            this.CMB_AllySlot3 = new System.Windows.Forms.ComboBox();
            this.CMB_AllySlot4 = new System.Windows.Forms.ComboBox();
            this.Party1 = new System.Windows.Forms.Label();
            this.Party2 = new System.Windows.Forms.Label();
            this.Party3 = new System.Windows.Forms.Label();
            this.Party4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CMB_AllySlot1
            // 
            this.CMB_AllySlot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CMB_AllySlot1.FormattingEnabled = true;
            this.CMB_AllySlot1.Location = new System.Drawing.Point(306, 76);
            this.CMB_AllySlot1.Name = "CMB_AllySlot1";
            this.CMB_AllySlot1.Size = new System.Drawing.Size(272, 28);
            this.CMB_AllySlot1.TabIndex = 0;
            this.CMB_AllySlot1.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // CMB_AllySlot2
            // 
            this.CMB_AllySlot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CMB_AllySlot2.FormattingEnabled = true;
            this.CMB_AllySlot2.Location = new System.Drawing.Point(306, 103);
            this.CMB_AllySlot2.Name = "CMB_AllySlot2";
            this.CMB_AllySlot2.Size = new System.Drawing.Size(272, 28);
            this.CMB_AllySlot2.TabIndex = 1;
            this.CMB_AllySlot2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // CMB_AllySlot3
            // 
            this.CMB_AllySlot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CMB_AllySlot3.FormattingEnabled = true;
            this.CMB_AllySlot3.Location = new System.Drawing.Point(306, 130);
            this.CMB_AllySlot3.Name = "CMB_AllySlot3";
            this.CMB_AllySlot3.Size = new System.Drawing.Size(272, 28);
            this.CMB_AllySlot3.TabIndex = 2;
            this.CMB_AllySlot3.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // CMB_AllySlot4
            // 
            this.CMB_AllySlot4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CMB_AllySlot4.FormattingEnabled = true;
            this.CMB_AllySlot4.Location = new System.Drawing.Point(306, 157);
            this.CMB_AllySlot4.Name = "CMB_AllySlot4";
            this.CMB_AllySlot4.Size = new System.Drawing.Size(272, 28);
            this.CMB_AllySlot4.TabIndex = 3;
            this.CMB_AllySlot4.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // Party1
            // 
            this.Party1.AutoSize = true;
            this.Party1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Party1.Location = new System.Drawing.Point(61, 79);
            this.Party1.Name = "Party1";
            this.Party1.Size = new System.Drawing.Size(53, 20);
            this.Party1.TabIndex = 4;
            this.Party1.Text = "label1";
            // 
            // Party2
            // 
            this.Party2.AutoSize = true;
            this.Party2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Party2.Location = new System.Drawing.Point(61, 106);
            this.Party2.Name = "Party2";
            this.Party2.Size = new System.Drawing.Size(53, 20);
            this.Party2.TabIndex = 5;
            this.Party2.Text = "label2";
            // 
            // Party3
            // 
            this.Party3.AutoSize = true;
            this.Party3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Party3.Location = new System.Drawing.Point(61, 133);
            this.Party3.Name = "Party3";
            this.Party3.Size = new System.Drawing.Size(53, 20);
            this.Party3.TabIndex = 6;
            this.Party3.Text = "label3";
            // 
            // Party4
            // 
            this.Party4.AutoSize = true;
            this.Party4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Party4.Location = new System.Drawing.Point(61, 160);
            this.Party4.Name = "Party4";
            this.Party4.Size = new System.Drawing.Size(53, 20);
            this.Party4.TabIndex = 7;
            this.Party4.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(61, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "CurrentParty:";
            // 
            // WagonForm
            // 
            this.ClientSize = new System.Drawing.Size(617, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Party4);
            this.Controls.Add(this.Party3);
            this.Controls.Add(this.Party2);
            this.Controls.Add(this.Party1);
            this.Controls.Add(this.CMB_AllySlot4);
            this.Controls.Add(this.CMB_AllySlot3);
            this.Controls.Add(this.CMB_AllySlot2);
            this.Controls.Add(this.CMB_AllySlot1);
            this.Name = "WagonForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TraderForm_FormClosed);
            this.Load += new System.EventHandler(this.TraderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CMB_AllySlot1;
        private System.Windows.Forms.ComboBox CMB_AllySlot2;
        private System.Windows.Forms.ComboBox CMB_AllySlot3;
        private System.Windows.Forms.ComboBox CMB_AllySlot4;
        private System.Windows.Forms.Label Party1;
        private System.Windows.Forms.Label Party2;
        private System.Windows.Forms.Label Party3;
        private System.Windows.Forms.Label Party4;
        private System.Windows.Forms.Label label1;
    }
}
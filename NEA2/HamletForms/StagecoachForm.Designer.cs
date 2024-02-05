namespace NEA2
{
    partial class StagecoachForm
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
            this.BuyNewChar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuyNewChar
            // 
            this.BuyNewChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyNewChar.Location = new System.Drawing.Point(1097, 674);
            this.BuyNewChar.Name = "BuyNewChar";
            this.BuyNewChar.Size = new System.Drawing.Size(75, 75);
            this.BuyNewChar.TabIndex = 0;
            this.BuyNewChar.Tag = "protected";
            this.BuyNewChar.Text = "Buy New Character (200g)";
            this.BuyNewChar.UseVisualStyleBackColor = true;
            this.BuyNewChar.Click += new System.EventHandler(this.BuyNewChar_Click);
            // 
            // StagecoachForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.BuyNewChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StagecoachForm";
            this.Text = "StagecoachForm";
            this.Load += new System.EventHandler(this.StagecoachForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuyNewChar;
    }
}
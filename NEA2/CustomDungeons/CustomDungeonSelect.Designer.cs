namespace NEA2.CustomDungeons
{
    partial class CustomDungeonSelect
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
            this.CreateDGN_Button = new System.Windows.Forms.Button();
            this.LoadDGN_Button = new System.Windows.Forms.Button();
            this.DGN_Key_TXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateDGN_Button
            // 
            this.CreateDGN_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.CreateDGN_Button.Location = new System.Drawing.Point(61, 46);
            this.CreateDGN_Button.Name = "CreateDGN_Button";
            this.CreateDGN_Button.Size = new System.Drawing.Size(125, 125);
            this.CreateDGN_Button.TabIndex = 0;
            this.CreateDGN_Button.Text = "Create";
            this.CreateDGN_Button.UseVisualStyleBackColor = true;
            this.CreateDGN_Button.Click += new System.EventHandler(this.CreateDGN_Button_Click);
            // 
            // LoadDGN_Button
            // 
            this.LoadDGN_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.LoadDGN_Button.Location = new System.Drawing.Point(511, 46);
            this.LoadDGN_Button.Name = "LoadDGN_Button";
            this.LoadDGN_Button.Size = new System.Drawing.Size(125, 125);
            this.LoadDGN_Button.TabIndex = 1;
            this.LoadDGN_Button.Text = "Load";
            this.LoadDGN_Button.UseVisualStyleBackColor = true;
            this.LoadDGN_Button.Click += new System.EventHandler(this.LoadDGN_Button_Click);
            // 
            // DGN_Key_TXT
            // 
            this.DGN_Key_TXT.Location = new System.Drawing.Point(345, 217);
            this.DGN_Key_TXT.Name = "DGN_Key_TXT";
            this.DGN_Key_TXT.Size = new System.Drawing.Size(464, 20);
            this.DGN_Key_TXT.TabIndex = 2;
            this.DGN_Key_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DGN_Key_TXT.TextChanged += new System.EventHandler(this.KeyTXT_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Key Below:";
            // 
            // CustomDungeonSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGN_Key_TXT);
            this.Controls.Add(this.LoadDGN_Button);
            this.Controls.Add(this.CreateDGN_Button);
            this.Name = "CustomDungeonSelect";
            this.Text = "CustomDungeonSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateDGN_Button;
        private System.Windows.Forms.Button LoadDGN_Button;
        private System.Windows.Forms.TextBox DGN_Key_TXT;
        private System.Windows.Forms.Label label1;
    }
}
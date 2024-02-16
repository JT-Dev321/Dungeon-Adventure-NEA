using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2.Save_Handling
{
    public partial class SaveFileNameInputLoad : Form
    {
        ComboBox CMB_FilePath;
        MainMenuForm ParentMainMenu;
        public SaveFileNameInputLoad(MainMenuForm parentMainMenu)
        {
            InitializeComponent();
            ParentMainMenu = parentMainMenu;
        }

        private void SFNI_OnLoad(object sender, EventArgs e)
        {
            CMB_FilePath = new ComboBox();
            CMB_FilePath.Size = new Size(375, 60);
            CMB_FilePath.Font = new Font(FontFamily.GenericSansSerif, 20);
            CMB_FilePath.Location = new Point(this.Width / 2 - CMB_FilePath.Width / 2, this.Height / 2 - CMB_FilePath.Height / 2 - 50);
            //$@"savegames/{FileNameInputText.Text}.txt"

            foreach (string filePath in Directory.GetFiles($@"savegames/"))
            {
                CMB_FilePath.Items.Add(filePath.Split(new string[] { $@"savegames/" }, StringSplitOptions.None)[1].Split(new string[] { ".txt" }, StringSplitOptions.None)[0]);
            }

            this.Controls.Add(CMB_FilePath);
            CMB_FilePath.Show();
        }

        private void BTN_SubmitSaveFileName_Click(object sender, EventArgs e)
        {
            string path = $@"savegames/{this.CMB_FilePath.SelectedItem.ToString()}.txt";

            if (File.Exists(path))
            {
                string fulltext = "";
                string[] readLines = File.ReadAllLines(path);
                foreach (string line in readLines)
                {
                    fulltext += line + "\n";
                    Console.WriteLine(line);
                }

                Game CurrentGame = new Game(fulltext, path);
                CurrentGame.SavePath = path;
                Utils.ShowForm(CurrentGame.MainHamlet, false);

                this.Hide();
                ParentMainMenu.Hide();
            }
            
        }
    }
}

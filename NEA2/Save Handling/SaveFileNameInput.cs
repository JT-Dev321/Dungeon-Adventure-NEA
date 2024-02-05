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
    public partial class SaveFileNameInput : Form
    {
        private Game CurrentGame = null;
        private MainMenuForm parentMenu;
        private bool forSaving;
        public SaveFileNameInput(Game currentGame = null, MainMenuForm MenuForm = null)
        {
            InitializeComponent();
            this.parentMenu = MenuForm;
            if (currentGame == null)
            {
                this.forSaving = false;
            }
            else
            {
                this.forSaving = true;
            }
            CurrentGame = currentGame;
        }

        private void On_InputTextChange(object sender, EventArgs e)
        {
            if (FileNameInputText.Text.Length > 6 && !FileNameInputText.Text.Contains(" "))
            {
                if (!forSaving)
                {
                    if (File.Exists($@"savegames/{FileNameInputText.Text}.txt"))
                    {
                        BTN_SubmitSaveFileName.Enabled = true;
                    }
                }
                else
                {
                    BTN_SubmitSaveFileName.Enabled = true;
                }
            }
            else
            {
                BTN_SubmitSaveFileName.Enabled = false;
                
            }
            


        }

        private void BTN_SubmitSaveFileName_Click(object sender, EventArgs e)
        {
            string path = $@"savegames/{FileNameInputText.Text}.txt";

            if (forSaving)
            {
                // saving a game logic
                this.CurrentGame.SavePath = path;
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(CurrentGame.Save());
                    }
                }
                this.Hide();
            }
            else
            {
                string fulltext = "";
                string[] readLines = File.ReadAllLines(path);
                foreach (string line in readLines)
                {
                    fulltext += line + "\n";
                    Console.WriteLine(line);
                }

                Game CurrentGame = new Game(fulltext, path);
                Utils.ShowForm(CurrentGame.MainHamlet, false);

                this.Hide();

                if (parentMenu != null)
                {
                    parentMenu.Hide();
                }
            }
        }
    }
}

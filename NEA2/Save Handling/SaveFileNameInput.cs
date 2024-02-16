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
using System.Text.RegularExpressions;

namespace NEA2.Save_Handling
{
    public partial class SaveFileNameInput : Form
    {
        private Game CurrentGame;
        public SaveFileNameInput(Game currentGame)
        {
            InitializeComponent();
            CurrentGame = currentGame;
        }

        private void On_InputTextChange(object sender, EventArgs e)
        {
            Console.WriteLine(Regex.Match(FileNameInputText.Text, @"^\w{6}\w*$").Success);
            if (Regex.Match(FileNameInputText.Text, @"^\w{6}\w*$").Success)
            {
                BTN_SubmitSaveFileName.Enabled = true;
            }
            else
            {
                BTN_SubmitSaveFileName.Enabled = false;
            }
        }

        private void BTN_SubmitSaveFileName_Click(object sender, EventArgs e)
        {
            string path = $@"savegames/{FileNameInputText.Text}.txt";

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
    }
}

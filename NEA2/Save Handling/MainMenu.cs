using NEA2.Save_Handling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            // General.CreateDungeon();
        }
        
        private void BTN_Start_Click(object sender, EventArgs e)
        {
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            BTN_Start.FlatAppearance.BorderSize = 0;
        }

        private void BTN_NewGame_Click(object sender, EventArgs e)
        {
            Game CurrentGame = new Game();
            Utils.ShowForm(CurrentGame.MainHamlet, false);
            this.Hide();
        }

        private void BTN_LoadSave_Click(object sender, EventArgs e)
        {
            // savegames - name of folder

            Utils.ShowForm(new SaveFileNameInput(null, this));
        }
    }
}

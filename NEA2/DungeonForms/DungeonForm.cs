using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEA2
{
    public partial class DungeonForm : Form
    {
        Dungeon dungeon;
        public bool shown = false;
        public DungeonForm(Dungeon dungeon)
        {
            this.dungeon = dungeon;
            InitializeComponent();
        }

        private void Dungeon1Form_Load(object sender, EventArgs e)
        {
            
        }

        private void ViewMap_Click(object sender, EventArgs e)
        {
            this.dungeon.UpdateMap(this.dungeon.MapForm.pbArr);
            this.dungeon.MapForm.Invalidate();
            Utils.ShowForm(this.dungeon.MapForm);
            
        }

        private void BTN_GoBack_Click(object sender, EventArgs e)
        {
            Utils.ShowForm(this.dungeon.game.MainEstateMap, false);
            this.Hide();
        }

        private void DungeonForm_Shown(object sender, EventArgs e)
        {
            shown = true;
        }
    }
}

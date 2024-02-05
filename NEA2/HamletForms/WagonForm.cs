using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA2.HamletForms
{
    public partial class WagonForm : Form
    {
        private Game game;
        public WagonForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private List<Character> ownedchars = new List<Character>(), currentparty = new List<Character>();
        private List<ComboBox> CMBoxes = new List<ComboBox>();
        private List<Label> PartyLabels = new List<Label>();
        private void TraderForm_Load(object sender, EventArgs e)
        {
            ownedchars = this.game.OwnedCharacters;
            currentparty = this.game.Party.ToList();
            CMBoxes = new List<ComboBox> { CMB_AllySlot1, CMB_AllySlot2, CMB_AllySlot3, CMB_AllySlot4 };
            PartyLabels = new List<Label> { Party1, Party2, Party3, Party4 };
            foreach (Character character in ownedchars.Concat(game.Party))
            {
                foreach (ComboBox cb in CMBoxes)
                {
                    cb.DisplayMember = "FullTitle";
                    cb.Items.Add(character);
                    cb.Refresh();
                }
            }
            for (int i = 0; i < currentparty.Count; i++)
            {
                PartyLabels[i].Text = currentparty[i].FullTitle;
                CMBoxes[i].SelectedItem = this.currentparty[i];
            }

        }

        private void TraderForm_FormClosed(object sender, FormClosingEventArgs e)
        {
            bool validParty = true;
            for (int i = 0; i < CMBoxes.Count; i++)
            {
                if (CMBoxes[i].SelectedItem == null)
                {
                    validParty = false;
                }
            }
            if (validParty)
            {
                for (int i = 0; i < CMBoxes.Count; i++)
                {
                    this.game.Party[i] = (Character)CMBoxes[i].SelectedItem;
                }
            }
            foreach (ComboBox cb in CMBoxes)
            {
                cb.Items.Clear();
            }
            this.ownedchars.Clear();
            this.currentparty.Clear();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox changedComboBox = (ComboBox)sender;

            foreach (ComboBox cb in CMBoxes)
            {
                if (cb != changedComboBox)
                {
                    if (changedComboBox.SelectedItem == cb.SelectedItem)
                    {
                        cb.SelectedIndex = -1;
                    }
                }
                cb.Refresh();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryDataCollection
{
    public partial class ChooseSplitState : Form
    {
        public string splitState { get; private set; }
        private int checkedIndex = 9999;    //donw to allow checking that a check has happened
        public ChooseSplitState()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                checkedIndex = e.Index;
                for (int i = 0; i < checkedListBox1.Items.Count; ++i)
                    if (e.Index != i) checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkedIndex == 9999)
            {
                MessageBox.Show("You must choose a Split State");
                return;
            }
            splitState = checkedListBox1.Items[checkedIndex].ToString();
            splitState = splitState.Substring(splitState.Length-3);    //gets the split state code
            Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
        }

    }
}

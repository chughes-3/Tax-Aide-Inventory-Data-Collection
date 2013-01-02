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
    public partial class HrDataPrevDisparity : Form
    {
        bool displayATag = false;
        bool displaySnum = false;
        public HrDataPrevDisparity()
        {
            InitializeComponent();
        }

        internal void SetRadButtons()
        {//rad but used later to determine which data is valid
            if (txtBxAtagDB.Text != string.Empty)
                radButAtagDB.Checked = true;
            else
                radButAtagIDC.Checked = true;
            if (txtBxDbSn.Text != string.Empty)
                radButSnDb.Checked = true;
            else
                radButSnIDC.Checked = true;
            if (txtBxATagIDC.Text != txtBxAtagDB.Text && (txtBxAtagDB.Text != string.Empty && txtBxATagIDC.Text != string.Empty))
            {
                this.groupBoxAt.Visible = true;    //we have an asset tag issue
                displayATag = true; //visible property is affected by parent control will only test true if parent is visible
            }
            if (txtBxDbSn.Text != txtBxIDCPrvSn.Text && (txtBxDbSn.Text != string.Empty && txtBxIDCPrvSn.Text != string.Empty))
            {
                groupBoxSn.Visible = true;    //we have an Serial Num issue
                displaySnum = true;
            }
            if (displayATag == true || displaySnum == true)
                this.ShowDialog();
            
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}

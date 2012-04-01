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
    public partial class ItemActions : Form
    {
        ListView listViewInvFile;
        int item;
        SystemsDataMultiple allSystemsData;
        ListView.ListViewItemCollection rows;
        string assetTag;
        string serialNoHR;
        int assetTagIndex;
        int serialNumHRIndex;
        string serialNoMR;
        public ItemActions(ref ListView listviewp, int itemp, ref SystemsDataMultiple allSystemsDatap)
        {
            InitializeComponent();
            listViewInvFile = listviewp;
            item = itemp;
            allSystemsData = allSystemsDatap;
            rows = listViewInvFile.Items;   //gets all the listview rows to work with in methods
            labelInitialStatement.Text += (item + 1).ToString();    //ROW is always item+1
            //next get assettag and serial index, then get data and load this form with that data
            int serialNumIndex = listViewInvFile.Columns.IndexOfKey("compSerialNum");  //index of the serial number column 
            serialNoMR = rows[item].SubItems[serialNumIndex].Text;   //gets the MR serial number from listview row
            assetTagIndex = listViewInvFile.Columns.IndexOfKey("compAssetTag");
            serialNumHRIndex = listViewInvFile.Columns.IndexOfKey("compSerialNumHR");
            if (rows[item].SubItems[assetTagIndex].Text != string.Empty)
                textboxAssetTag.Text = rows[item].SubItems[assetTagIndex].Text;
            if (rows[item].SubItems[serialNumHRIndex].Text != string.Empty)
                textBoxSerialNo.Text = rows[item].SubItems[serialNumHRIndex].Text;
            assetTag = textboxAssetTag.Text;
            serialNoHR = textBoxSerialNo.Text;
        }

        private void deleteRow_Click(object sender, EventArgs e)
        {
            allSystemsData.SystemDataDelete(serialNoMR);
            rows.RemoveAt(item);
            //update row numbers
            for (int i = 0; i <= listViewInvFile.Items.Count - 1; i++)
            {
                ListViewItem.ListViewSubItemCollection det = listViewInvFile.Items[i].SubItems;
                det[0].Text = (i + 1).ToString();
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxBeforeRow_Enter(object sender, EventArgs e)
        {
            textBoxAfter.Text = "";
        }

        private void textBoxAfter_Enter(object sender, EventArgs e)
        {
            textBoxBeforeRow.Text = "";
        }

        private void textboxAssetTag_Enter(object sender, EventArgs e)
        {
            if (textboxAssetTag.Text == "Asset Tag")
                textboxAssetTag.Text = "";
        }

        private void textboxAssetTag_Leave(object sender, EventArgs e)
        {
            if (textboxAssetTag.Text != "Asset Tag" && textboxAssetTag.Text.Trim() != assetTag)
            {
                rows[item].SubItems[assetTagIndex].Text = textboxAssetTag.Text.Trim();
                allSystemsData.SystemChangeAsset(serialNoMR, textboxAssetTag.Text.Trim());
            }
        }

        private void textBoxSerialNo_Enter(object sender, EventArgs e)
        {
            if (textBoxSerialNo.Text == "Serial Number")
                textBoxSerialNo.Text = "";
        }

        private void textBoxSerialNo_Leave(object sender, EventArgs e)
        {
            if (textBoxSerialNo.Text != "Serial Number" && textBoxSerialNo.Text.Trim() != serialNoHR)
            {
                rows[item].SubItems[serialNumHRIndex].Text = textBoxSerialNo.Text.Trim();
                allSystemsData.SystemChangeSerial(serialNoMR,textBoxSerialNo.Text.Trim());
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int newRow;
            if (textBoxBeforeRow.Text != "")
            {
                newRow = int.Parse(textBoxBeforeRow.Text);
                newRow--;  //change from 1 based row number to zero based
                MoveRow(newRow);
            }
            else if (textBoxAfter.Text != "")
            {
                newRow = int.Parse(textBoxAfter.Text);  //This number is already zero based
                MoveRow(newRow);
            }
            Close();
        }

        private void MoveRow(int newRow)
        {
            listViewInvFile.Sorting = SortOrder.None;
            ListViewItem lvItem = rows[item];
            if (newRow < 0)
            {
                newRow = 0;
            }
            else if (newRow > rows.Count)
            {
                newRow = rows.Count;
            }
            if (newRow > item)
            {
                newRow--;
            }
            rows.RemoveAt(item);
            rows.Insert(newRow, lvItem);
            //MessageBox.Show(string.Format("item: {0} + new = {1}", item, newRow));
            item = newRow;
            //update row numbers
            for (int i = 0; i <= listViewInvFile.Items.Count - 1; i++)
            {
                ListViewItem.ListViewSubItemCollection det = listViewInvFile.Items[i].SubItems;
                det[0].Text = (i + 1).ToString();
            }
            return;
        }

        private void textBoxBeforeRow_Leave(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBoxBeforeRow.Text, out result) == false && textBoxBeforeRow.Text != string.Empty)
            {
                MessageBox.Show("The value must be numeric", "Inventory Data Collection");
                textBoxBeforeRow.Focus();
            }
        }

        private void textBoxAfter_Leave(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBoxAfter.Text, out result) == false && textBoxAfter.Text != string.Empty)
            {
                MessageBox.Show("The value must be numeric", "Inventory Data Collection");
                textBoxAfter.Focus();
            }

        }


    }
}

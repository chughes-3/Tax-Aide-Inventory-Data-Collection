﻿using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace InventoryDataCollection
{
    public partial class SysDsplyForm : Form
    {
        //Column names for this form MUST be same as exposed properties of SystemData class that should be displayed

        SystemData thisSystemData = new SystemData();  //Will do all wmi stuff and load dictionary;
        SystemsDataMultiple allSystemsData = new SystemsDataMultiple();  //will load all data from file if it exists;
        private int sortColumn = -1;    //used by sorting routine to record last column clicked
        ListViewItem lvItemThisSys;
        public SysDsplyForm()
        {
            InitializeComponent();
            textBoxThisSys.AppendText("Name = " + thisSystemData.compName + "\r\n"); 
            //Log.WritWTime("done W32 Comp sys");
            textBoxThisSys.AppendText("Manufacturer = " + thisSystemData.compManufacturer + "\r\n");
            textBoxThisSys.Lines[1] = "tae";
            textBoxThisSys.AppendText("Model = " + thisSystemData.compModel + "\r\n");
            textBoxThisSys.AppendText("Serial Number = " + thisSystemData.compSerialNum + "\r\n");
            textBoxThisSys.AppendText("Clock Speed = " + thisSystemData.compClockSpeed + "Mhz" + "\r\n");
            textBoxThisSys.AppendText("Memory = " + thisSystemData.compMemory + "MB" + "\r\n");
            textBoxThisSys.AppendText("Disk Size = " + thisSystemData.compDiskSize + "GB" + "\r\n");
            textBoxThisSys.AppendText("Operating System = " + thisSystemData.osCaption + "\r\n");
            textBoxThisSys.AppendText("OS Version = " + thisSystemData.osVersion + "\r\n");
            textBoxThisSys.AppendText("Full Key = " + thisSystemData.osProductKey + "\r\n");
            if (thisSystemData.osProductKey == "BBBBB-BBBBB-BBBBB-BBBBB-BBBBB")
                textBoxThisSys.AppendText("Partial Product Key = " + thisSystemData.osPartialKey);
            //Add this system to data storage then set up listview
            allSystemsData.SystemDataAdd(thisSystemData);
            //Now we have keys we can setup listview columns
            SetLVColumns();
            int row = 1;
            foreach (SystemData item in allSystemsData)
            {//Special enumerator to get just systemdata out of dictionary
                string[] lvSubItems = new string[listViewInvFile.Columns.Count];
                foreach (ColumnHeader col in listViewInvFile.Columns)
                {
                    if (col.Name == "row")
                    {
                        lvSubItems[0] = row.ToString();
                        row++;
                    }
                    else
                    {
                        System.Reflection.PropertyInfo prop = item.GetType().GetProperty(col.Name.ToString());
                        lvSubItems[col.Index] = (string)prop.GetValue(item, null);
                    }

                }
                lvItemThisSys = new ListViewItem(lvSubItems);
                listViewInvFile.Items.Add(lvItemThisSys);
            }
            listViewInvFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            foreach (ColumnHeader col in listViewInvFile.Columns)
            {
                if (col.Width < 70)
                    col.Width = 70;
                if (col.Width > 200)
                    col.Width = 200;
            }
            int colIndex = listViewInvFile.Columns.IndexOfKey("compClockSpeed");
            listViewInvFile.AutoResizeColumn(colIndex, ColumnHeaderAutoResizeStyle.HeaderSize);
            colIndex = listViewInvFile.Columns.IndexOfKey("compMemory"); 
            listViewInvFile.AutoResizeColumn(colIndex, ColumnHeaderAutoResizeStyle.HeaderSize);
            colIndex = listViewInvFile.Columns.IndexOfKey("compDiskSize"); 
            listViewInvFile.AutoResizeColumn(colIndex, ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewInvFile.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);     //sets row column up
        }
        /// <summary>
        /// Sets up columns - Designer did not do name and tag properly
        /// The name (or Key) MUST BE IDENTICAL to aSystedata property so that the column gets filled correctly
        /// </summary>
        private void SetLVColumns()
        {
            listViewInvFile.Columns.Add("row", "Row", 30);
            listViewInvFile.Columns.Add("compName", "Name", 80);
            listViewInvFile.Columns.Add("compAssetTag", "Asset Tag", 100);
            listViewInvFile.Columns.Add("compSerialNumHR", "Label Serial No.", 80);
            listViewInvFile.Columns.Add("compManufacturer", "Manufacturer", 105);
            listViewInvFile.Columns.Add("compModel", "Model", 80);
            listViewInvFile.Columns.Add("compSerialNum", "Serial Number", 80);
            listViewInvFile.Columns.Add("compClockSpeed", "CPU(MHz)", 60, HorizontalAlignment.Right, null);
            listViewInvFile.Columns.Add("compMemory", "Memory(MB)", 60, HorizontalAlignment.Right, null);
            listViewInvFile.Columns.Add("compDiskSize", "Disk(GB)", 60, HorizontalAlignment.Right, null);
            listViewInvFile.Columns.Add("osCaption", "OS", 130);
            listViewInvFile.Columns.Add("osVersion", "OS Version", 100);
            if (thisSystemData.osProductKey == "BBBBB-BBBBB-BBBBB-BBBBB-BBBBB")
                listViewInvFile.Columns.Add("osPartialKey", "Partial Key", 100);
            else
                listViewInvFile.Columns.Add("osProductKey", "Product Key", 100);
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlTextWriter wxml = new XmlTextWriter(SystemsDataMultiple.path + SystemsDataMultiple.fileName, null);
            wxml.Formatting = Formatting.Indented;
            wxml.WriteStartDocument(true);
            wxml.WriteComment("IDC XML Version 2012.01");
            wxml.WriteStartElement("Systems");
            ListView.ListViewItemCollection rows = listViewInvFile.Items;
            int serialNumIndex = listViewInvFile.Columns.IndexOfKey("compSerialNum") ;   
            for (int i = 0; i < listViewInvFile.Items.Count; i++)
            {
                string serial = rows[i].SubItems[serialNumIndex].Text;
                System.Xml.Linq.XElement xsystem = allSystemsData.SystemXElement(serial.ToString());
                xsystem.WriteTo(wxml);
            }
            if (listViewInvFile.Items.Count == 1)
            {//fakes out excel so it puts in column headers
                wxml.WriteStartElement("system");
                wxml.WriteEndElement();
            }
            wxml.WriteEndElement();
            wxml.WriteEndDocument();
            wxml.Close();
            Environment.Exit(0);
        }

        private void entryAssetTag_Enter(object sender, EventArgs e)
        {
            if (entryAssetTag.Text == "Asset Tag")
            {
                entryAssetTag.Text = "";
            }
        }

        private void entryAssetTag_Leave(object sender, EventArgs e)
        {
            thisSystemData.compAssetTag = entryAssetTag.Text;
            ListView.ListViewItemCollection rows = listViewInvFile.Items;
            int compAssetIndex = listViewInvFile.Columns.IndexOfKey("compAssetTag") ;
            int itemThisSys = listViewInvFile.Items.IndexOf(lvItemThisSys);
            rows[itemThisSys].SubItems[compAssetIndex].Text = entryAssetTag.Text;
        }

        private void serialNumHR_Enter(object sender, EventArgs e)
        {
            if (serialNumHR.Text == "Serial Number")
            {
                serialNumHR.Text = "";
            }
        }

        private void serialNumHR_Leave(object sender, EventArgs e)
        {
            thisSystemData.compSerialNumHR = serialNumHR.Text;
            ListView.ListViewItemCollection rows = listViewInvFile.Items;
            int compSerialHRIndex = listViewInvFile.Columns.IndexOfKey("compSerialNumHR") ;
            int itemThisSys = listViewInvFile.Items.IndexOf(lvItemThisSys);
            rows[itemThisSys].SubItems[compSerialHRIndex].Text = serialNumHR.Text;
        }

        private void listViewInvFile_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                listViewInvFile.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (listViewInvFile.Sorting == SortOrder.Ascending)
                    listViewInvFile.Sorting = SortOrder.Descending;
                else
                    listViewInvFile.Sorting = SortOrder.Ascending;
            }

            // Set the ListViewItemSorter property to a new ListViewItemComparer object.
            this.listViewInvFile.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewInvFile.Sorting);
            // Call the sort method to manually sort.
            listViewInvFile.Sort();
            //update row numbers
            for (int i = 0; i <= listViewInvFile.Items.Count - 1; i++)
            {
                ListViewItem.ListViewSubItemCollection det = listViewInvFile.Items[i].SubItems;
                det[0].Text = (i+1).ToString();
            }

        }
        class ListViewItemComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public ListViewItemComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                // Determine whether the sort order is descending.
                if (order == SortOrder.Descending)
                    // Invert the value returned by String.Compare.
                    returnVal *= -1;
                return returnVal;
            }
        }

        private void listViewInvFile_ItemActivate(object sender, EventArgs e)
        {
            ItemActions rowAction = new ItemActions(ref listViewInvFile,listViewInvFile.SelectedIndices[0], ref allSystemsData);
            rowAction.ShowDialog();
        }
    }
}
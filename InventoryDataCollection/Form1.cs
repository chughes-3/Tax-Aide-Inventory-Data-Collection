using System;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace InventoryDataCollection
{
    public partial class Form1 : Form
    {

        StreamWriter file;  //for outputting file
        string path;  // path to program for data file
        string fileName = "\\TaxAideInvData.csv";
        int alreadyPresentFlag = 0;
        StringBuilder sysStr = new StringBuilder();  // builds string that will eventually be written to file. Different than listview because no MB,GB etc
        public Form1()
        {
            InitializeComponent();
            Regex regExpCommaFind = new Regex(",");  //To remove commas from strings
            WMI wmi = new WMI();
            wmi.ComputerSystem();
            listBoxThisSys.Items.Add("Name = " + wmi.sysWmi["name"]); //starts build string for file output and adds line to listbox
            sysStr.Append(wmi.sysWmi["name"] + ",");
            //Log.WritWTime("done W32 Comp sys");
            wmi.BiosMotherBoard();  //builds manufacturer serial number fields Adds the lines to listbox in method
            listBoxThisSys.Items.Add("Manufacturer = " + wmi.sysWmi["manufacturer"]);
            sysStr.Append(wmi.sysWmi["manufacturer"] + ",");
            listBoxThisSys.Items.Add("Model = " + wmi.sysWmi["model"]);
            sysStr.Append(wmi.sysWmi["model"] + ",");
            listBoxThisSys.Items.Add("Serial Number = " + wmi.sysWmi["serialnum"]);
            sysStr.Append(wmi.sysWmi["serialnum"] + ",");
            wmi.Proc();
            listBoxThisSys.Items.Add("Clock Speed = " + wmi.sysWmi["clockSpeed"] + "Mhz");  //memory originally obtained in computer system
            sysStr.Append(wmi.sysWmi["clockSpeed"] + ",");
            listBoxThisSys.Items.Add("Memory = " + wmi.sysWmi["memory"] + "MB");
            sysStr.Append(wmi.sysWmi["memory"] + ",");
            wmi.DiskDrive();
            listBoxThisSys.Items.Add("Disk Size = " + wmi.sysWmi["diskSize"] + "GB");
            sysStr.Append(wmi.sysWmi["diskSize"] + ",");
            wmi.OS();  // writes OS version text and numeric to listbox and string for file
            listBoxThisSys.Items.Add("Operating System = " + wmi.sysWmi["OScaption"]);
            sysStr.Append(wmi.sysWmi["OScaption"] + ",");
            listBoxThisSys.Items.Add("OS Version = " + wmi.sysWmi["OSversion"]);
            sysStr.Append(wmi.sysWmi["OSversion"] + ",");
            wmi.SysLicService();
            listBoxThisSys.Items.Add("Partial Product Key = " + wmi.sysWmi["partialKey"]);
            sysStr.Append(wmi.sysWmi["partialKey"] + ",");
            //Log.WritWTime("Done wmi queries");
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!File.Exists(path + fileName))
            {//if file does NOT exist need to write out column headers otherwise just append.
                file = new StreamWriter(path + fileName);
                StringBuilder str = new StringBuilder();
                foreach (ColumnHeader col in listViewInvFile.Columns)
                {
                    str.Append(col.Text + ",");
                }
                str.Remove(str.Length - 1, 1);
                file.WriteLine(str.ToString());
                file.Close();
            }
            string[] elementsThisSys = sysStr.ToString().Split(new char[] { ',' }, StringSplitOptions.None);
            //Log.WritWTime("New System string created");
            using (StreamReader filein = new StreamReader(path + fileName))
            {
                string line;
                filein.ReadLine(); //gets rid of first title line
                while ((line = filein.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] elements = line.Split(new char[] { ',' }, StringSplitOptions.None);
                        ListViewItem item = new ListViewItem(elements);
                        listViewInvFile.Items.Add(item);
                        if (elements[1] == elementsThisSys[1] && elements[2] == elementsThisSys[2] && elements[3] == elementsThisSys[3])
                        {//this system already in the file
                            alreadyPresentFlag = 1;
                        }

                    }
                }
            }
            if (alreadyPresentFlag == 0)
            {
                ListViewItem item1 = new ListViewItem(elementsThisSys);
                listViewInvFile.Items.Add(item1);
                using (file = new StreamWriter(path + fileName, true))
                {
                    file.Write(sysStr.ToString());  // do not write line allow for asset tag etc
                }
                listViewInvFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewInvFile.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewInvFile.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewInvFile.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                listViewInvFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewInvFile.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewInvFile.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
                listViewInvFile.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
                this.Show();
                MessageBox.Show("This system (Manufacturer, model, serial number) is already in the Inventory Data File", "Tax-Aide Inventory Data Collection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (ColumnHeader col in listViewInvFile.Columns)
            {
                if (col.Width < 60)
                {
                    col.Width = 60;
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (alreadyPresentFlag == 0)
            {
                file = new StreamWriter(path + fileName, true);
                if (entryAssetTag.Text != "Asset Tag")
                    file.Write(entryAssetTag.Text + ",");
                else
                    file.Write(",");
                if (serialNumHR.Text != "Serial Number" + ",")
                    file.WriteLine(serialNumHR.Text);
                else
                    file.WriteLine(",");
                file.Close();
            }
            Environment.Exit(0);
        }

        private void entryAssetTag_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void entryAssetTag_Enter(object sender, EventArgs e)
        {
            if (entryAssetTag.Text == "Asset Tag")
            {
                entryAssetTag.Text = "";
            }
        }

        private void serialNumHR_Enter(object sender, EventArgs e)
        {
            if (serialNumHR.Text == "Serial Number")
            {
                serialNumHR.Text = "";
            }
        }
    }
}

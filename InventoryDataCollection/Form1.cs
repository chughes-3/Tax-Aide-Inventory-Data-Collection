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
        public Form1()
        {
            string manufacturer = string.Empty;
            string model = string.Empty;
            string memory = string.Empty;
            string serialnum = string.Empty;
            StringBuilder sysStr = new StringBuilder();  // builds string that will eventually be written to file. Different than listview because no MB,GB etc

            InitializeComponent();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name,Manufacturer,Model,TotalPhysicalMemory FROM Win32_ComputerSystem");
                ManagementObjectCollection system = searcher.Get();
                foreach (ManagementObject queryObj in system)
                {
                    this.listBoxThisSys.Items.Add("Name = " + queryObj.GetPropertyValue("Name").ToString());
                    sysStr.Append(queryObj.GetPropertyValue("Name").ToString() + ",");
                    manufacturer = queryObj.GetPropertyValue("Manufacturer").ToString();
                    model = queryObj.GetPropertyValue("Model").ToString();
                    memory = ((UInt64)queryObj.GetPropertyValue("TotalPhysicalMemory") / 1048576).ToString();
                }
                //Log.WritWTime("done W32 Comp sys");
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer,SerialNumber FROM Win32_BIOS");
                ManagementObjectCollection bios = searcher.Get();
                //Log.WritWTime("bios info = " + bios.Count.ToString());
                foreach (ManagementObject queryObj in bios)
                {
                    if (queryObj.GetPropertyValue("SerialNumber") == null)
                    {
                        serialnum = string.Empty;
                    }
                    else
                    serialnum = queryObj.GetPropertyValue("SerialNumber").ToString().Trim();
                    Regex alpha = new Regex(@"^[A-Za-z\s]+$");
                    if (alpha.IsMatch(serialnum))
                    {// IS alphabetic or space therefore presumed not to be real serial number
                        serialnum = string.Empty;
                    }
                    if (serialnum == string.Empty)
                    {
                        ManagementObjectSearcher searcherbb = new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer,SerialNumber FROM Win32_Baseboard");
                        ManagementObjectCollection baseboard = searcherbb.Get();
                        foreach (ManagementObject item in baseboard)
                        {
                            if (alpha.IsMatch(model))
                            {//If we have a non useful serial we test the model to make sure that is useful
                                model = "Motherboard";
                            } 
                            manufacturer = item.GetPropertyValue("Manufacturer").ToString();
                            serialnum = item.GetPropertyValue("SerialNumber").ToString();
                        }
                    }
                    else 
                        serialnum = queryObj.GetPropertyValue("SerialNumber").ToString();
                }
                listBoxThisSys.Items.Add("Manufacturer = " + manufacturer);
                sysStr.Append(manufacturer + ",");
                listBoxThisSys.Items.Add("Model = " + model);
                sysStr.Append(model + ",");
                listBoxThisSys.Items.Add("Serial Number = " + serialnum);
                sysStr.Append(serialnum + ",");
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT MaxClockSpeed FROM Win32_Processor");
                ManagementObjectCollection proc = searcher.Get();
                foreach (ManagementObject queryObj in proc)
                {//memory already in place insert before
                    listBoxThisSys.Items.Add("Clock Speed = " + queryObj.GetPropertyValue("MaxClockSpeed").ToString() + "Mhz");
                    sysStr.Append(queryObj.GetPropertyValue("MaxClockSpeed").ToString() + ",");
                }
                listBoxThisSys.Items.Add("Memory = " + memory + "MB");
                sysStr.Append(memory + ",");
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Size,MediaType FROM Win32_DiskDrive");
                ManagementObjectCollection disk = searcher.Get();
                UInt64 diskSize = 0;
                foreach (ManagementObject queryObj in disk)
                {
                    if (queryObj.GetPropertyValue("MediaType") == null || queryObj.GetPropertyValue("Size") == null)
                    {
                        continue; 
                    }
                    if (queryObj.GetPropertyValue("MediaType").ToString().Contains("Fixed"))
                    {
                        diskSize += (UInt64)queryObj.GetPropertyValue("Size");
                    }
                }
                //Log.WritWTime("disk size = " + (diskSize/1073741824).ToString());
                listBoxThisSys.Items.Add("Disk Size = " + (diskSize / 1073741824).ToString() + "GB");
                sysStr.Append((diskSize / 1073741824).ToString() + ",");
                ManagementObjectSearcher searcheros = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption,Version FROM Win32_OperatingSystem");
                ManagementObjectCollection os = searcheros.Get();
                foreach (ManagementObject queryObj in os)
                {
                    listBoxThisSys.Items.Add("Operating System = " + queryObj.GetPropertyValue("Caption").ToString().Substring(10)); //Eliminiate Microsoft from the OS name
                    sysStr.Append(queryObj.GetPropertyValue("Caption").ToString().Substring(10)); //Eliminiate Microsoft from the OS name
                    listBoxThisSys.Items.Add("OS Version = " + queryObj.GetPropertyValue("Version").ToString());
                    sysStr.Append(queryObj.GetPropertyValue("Version").ToString());
                }
                //Log.WritWTime("Done wmi queries");
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
            }
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StreamWriter file;
            if (!File.Exists(path + "\\TaxAideInvData.txt"))
            {//if file does NOT exist need to write out column headers otherwise just append.
                file = new StreamWriter(path + "\\TaxAideInvData.txt");
                foreach (ColumnHeader col in listViewInvFile.Columns)
                {
                    file.Write(col.Text + ",");
                }
                file.WriteLine();
                file.Close();
            }
            string[] elementsThisSys = sysStr.ToString().Split(new char[] { ',' }, StringSplitOptions.None);
            //Log.WritWTime("New System string created");
            int alreadyPresentFlag = 0;
            using (StreamReader filein = new StreamReader(path + "\\TaxAideInvData.txt"))
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
            listViewInvFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewInvFile.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewInvFile.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewInvFile.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize);
            if (alreadyPresentFlag == 0)
            {
                ListViewItem item1 = new ListViewItem(elementsThisSys);
                listViewInvFile.Items.Add(item1);
                using (file = new StreamWriter(path + "\\TaxAideInvData.txt", true))
                {
                    file.WriteLine(sysStr.ToString());
                }
            }
            else
            {
                this.Show();
                MessageBox.Show("This system (Manufacturer, model, serial number) is already in the Inventory Data File", "Tax-Aide Inventory Data Collection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

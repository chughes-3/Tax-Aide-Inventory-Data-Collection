using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace InventoryDataCollection
{
    class WMI
    {
        internal Dictionary<string, string> sysWmi = new Dictionary<string, string>();

        UInt64 diskSize = 0;    // needed here for VB serial number calc
        UInt64 memory = 0;
        Regex regExpCommaFind = new Regex(",");  //To remove commas from strings
        ManagementObjectSearcher searcher;
        internal void ComputerSystem()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name,Manufacturer,Model,TotalPhysicalMemory FROM Win32_ComputerSystem");
                ManagementObjectCollection system = searcher.Get();
                foreach (ManagementObject queryObj in system)
                {
                    string name = regExpCommaFind.Replace(queryObj.GetPropertyValue("Name").ToString(), "");
                    sysWmi.Add("name", name.Trim());
                    string mfr = regExpCommaFind.Replace(queryObj.GetPropertyValue("Manufacturer").ToString(), "");
                    sysWmi.Add("manufacturer", mfr.Trim());
                    string model = regExpCommaFind.Replace(queryObj.GetPropertyValue("Model").ToString(), "");
                    sysWmi.Add("model", model.Trim());
                    memory = (UInt64)queryObj.GetPropertyValue("TotalPhysicalMemory");
                    sysWmi.Add("memory", (memory / 1048576).ToString());
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying ComputerSystem WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }

        internal void BiosMotherBoard()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer,SerialNumber FROM Win32_BIOS");
                ManagementObjectCollection bios = searcher.Get();
                //Log.WritWTime("bios info = " + bios.Count.ToString());
                foreach (ManagementObject queryObj in bios)
                {
                    if (queryObj.GetPropertyValue("SerialNumber") == null)
                    {
                        sysWmi.Add("serialnum", string.Empty);
                    }
                    else
                        sysWmi.Add("serialnum", queryObj.GetPropertyValue("SerialNumber").ToString().Trim());
                    Regex alpha = new Regex(@"^[A-Za-z\s]+$");
                    if (alpha.IsMatch(sysWmi["serialnum"]))
                    {// IS alphabetic or space therefore presumed not to be real serial number
                        sysWmi["serialnum"] = string.Empty;
                    }
                    if (sysWmi["serialnum"] == string.Empty)
                    {
                        ManagementObjectSearcher searcherbb = new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer,SerialNumber FROM Win32_Baseboard");
                        ManagementObjectCollection baseboard = searcherbb.Get();
                        foreach (ManagementObject item in baseboard)
                        {
                            if (alpha.IsMatch(sysWmi["model"]))
                            {//If we have a non useful serial we test the model to make sure that is useful
                                sysWmi["model"] = "Motherboard";
                            }
                            sysWmi["manufacturer"] = item.GetPropertyValue("Manufacturer").ToString().Trim();
                            sysWmi["serialnum"] = item.GetPropertyValue("SerialNumber").ToString().Trim();
                        }
                    }
                    else
                        sysWmi["serialnum"] = queryObj.GetPropertyValue("SerialNumber").ToString().Trim();
                }
                sysWmi["manufacturer"] = regExpCommaFind.Replace(sysWmi["manufacturer"], "").Trim();    // remove commas
                sysWmi["model"] = regExpCommaFind.Replace(sysWmi["model"], "").Trim();
                sysWmi["serialnum"] = regExpCommaFind.Replace(sysWmi["serialnum"], "").Trim();

                if (sysWmi["manufacturer"] == "innotek GmbH" && (sysWmi["serialnum"] == "0" || sysWmi["serialnum"] == "")) //We have aVirtual Box systemtrue)
                {
                    VBoxSerial();   // setup serial number for virtual box
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying Baseboard or BIOS WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void Proc()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT MaxClockSpeed FROM Win32_Processor");
                ManagementObjectCollection proc = searcher.Get();
                foreach (ManagementObject queryObj in proc)
                {//memory already in place insert before
                    sysWmi["clockSpeed"] = regExpCommaFind.Replace(queryObj.GetPropertyValue("MaxClockSpeed").ToString(), "");
                }

            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying Processor WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void DiskDrive()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Size,MediaType FROM Win32_DiskDrive");
                ManagementObjectCollection disk = searcher.Get();
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
                sysWmi["diskSize"] = (diskSize / 1073741824).ToString();

            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void OS()
        {
            try
            {
                ManagementObjectSearcher searcheros = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption,Version FROM Win32_OperatingSystem");
                ManagementObjectCollection os = searcheros.Get();
                foreach (ManagementObject queryObj in os)
                {
                    sysWmi["OScaption"] = queryObj.GetPropertyValue("Caption").ToString().Substring(10); //Eliminiate Microsoft from the OS name
                    sysWmi["OSversion"] = queryObj.GetPropertyValue("Version").ToString();
                }

            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying OperatingSystem WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void SysLicServicePartialKey()
        {
            if (sysWmi["OScaption"] != "Windows 7 Professional ")
            {
                sysWmi["partialKey"] = "";
                return;
            }
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT PartialProductKey FROM SoftwareLicensingProduct");
                ManagementObjectCollection keys = searcher.Get();
                foreach (ManagementObject queryObj in keys)
                {
                    sysWmi["partialKey"] = (string)queryObj.GetPropertyValue("PartialProductKey");
                    if (sysWmi["partialKey"] != null)
                    {
                        break;
                    }
                }
                if (sysWmi["partialKey"] == null)
                {
                    sysWmi["partialKey"] = "";
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying SoftwareLicensingProduct WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal int ReArmWin()
        {
            UInt32 reArmCount = 0;
            searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT RemainingWindowsReArmCount FROM SoftwareLicensingService");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                foreach (PropertyData item in queryObj.Properties)
                {
                    reArmCount = (UInt32)item.Value;
                }
            }

            if (reArmCount > 0)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = Environment.SystemDirectory.Substring(0, 2) + "\\SyncCommands\\slmgrmine.vbs";
                proc.StartInfo.Arguments = "/rearm";
                proc.Start();
                while (!proc.HasExited)
                {
                    System.Threading.Thread.Sleep(500);
                }
                return 1;
            }
            else
                return 0;
        }
        internal void RemoveKey()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Environment.SystemDirectory.Substring(0, 2) + "\\SyncCommands\\slmgrmine.vbs";
            proc.StartInfo.Arguments = "/upk ";
            proc.Start();
            while (!proc.HasExited)
            {
                System.Threading.Thread.Sleep(500);
            }
        }
        internal void LicInstall(string productKey)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Environment.SystemDirectory.Substring(0, 2) + "\\SyncCommands\\slmgrmine.vbs";
            proc.StartInfo.Arguments = "/ipk " + productKey;
            proc.Start();
            while (!proc.HasExited)
            {
                System.Threading.Thread.Sleep(500);
            }
        }
        void VBoxSerial()
        {
            DiskDrive();
            //at this point assume we have memory and disl size then
            sysWmi["serialnum"] = diskSize.ToString() + ":" + memory.ToString();
            return;
        }
    }
}

﻿using System;
using System.Text;
using System.Management;
using System.Collections;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace InventoryDataCollection
{
    class WMI
    {
        SystemData sysData;
        UInt64 diskSize = 0;    // needed here for VB serial number calc
        UInt64 memory = 0;
        string macAddress;
        Regex regExpCommaFind = new Regex(",");  //To remove commas from strings
        ManagementObjectSearcher searcher;
        public WMI(SystemData thisSys)
        {
            sysData = thisSys;
        }
        internal void ComputerSystem()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name,Manufacturer,Model,TotalPhysicalMemory FROM Win32_ComputerSystem");
                ManagementObjectCollection system = searcher.Get();
                foreach (ManagementObject queryObj in system)
                {
                    string name = regExpCommaFind.Replace(queryObj.GetPropertyValue("Name").ToString(), "");
                    sysData.compName = name.Trim();
                    string mfr = regExpCommaFind.Replace(queryObj.GetPropertyValue("Manufacturer").ToString(), "");
                    sysData.compManufacturer = mfr.Trim();
                    string model = regExpCommaFind.Replace(queryObj.GetPropertyValue("Model").ToString(), "");
                    sysData.compModel = model.Trim();
                    memory = (UInt64)queryObj.GetPropertyValue("TotalPhysicalMemory");
                    sysData.compMemory = (memory / 1048576).ToString();
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
                    if (queryObj.GetPropertyValue("SerialNumber") != null)
                        sysData.compSerialNum = queryObj.GetPropertyValue("SerialNumber").ToString().Trim();
                    Regex alpha = new Regex(@"^[A-Za-z\s]+$");
                    if (alpha.IsMatch(sysData.compSerialNum))
                    {// IS alphabetic or space therefore presumed not to be real serial number
                        sysData.compSerialNum = string.Empty;
                    }
                    if (sysData.compSerialNum == string.Empty)
                    {
                        ManagementObjectSearcher searcherbb = new ManagementObjectSearcher("root\\CIMV2", "SELECT Manufacturer,SerialNumber FROM Win32_Baseboard");
                        ManagementObjectCollection baseboard = searcherbb.Get();
                        foreach (ManagementObject item in baseboard)
                        {
                            if (alpha.IsMatch(sysData.compModel))
                            {//If we have a non useful serial we test the model to make sure that is useful
                                sysData.compModel = "Motherboard";
                            }
                            sysData.compManufacturer = item.GetPropertyValue("Manufacturer").ToString().Trim();
                            if (item.GetPropertyValue("SerialNumber") != null)
                            {
                                sysData.compSerialNum = item.GetPropertyValue("SerialNumber").ToString().Trim();
                            }
                        }
                    }
                    else
                        sysData.compSerialNum = queryObj.GetPropertyValue("SerialNumber").ToString().Trim();
                }
                sysData.compManufacturer = regExpCommaFind.Replace(sysData.compManufacturer, "").Trim();    // remove commas
                sysData.compModel = regExpCommaFind.Replace(sysData.compModel, "").Trim();
                sysData.compSerialNum = regExpCommaFind.Replace(sysData.compSerialNum, "").Trim();

                if (sysData.compManufacturer == "innotek GmbH" && (sysData.compSerialNum == "0" || sysData.compSerialNum == "")) //We have aVirtual Box systemtrue)
                {
                    VBoxSerial();   // setup serial number for virtual box
                }
                if (sysData.compSerialNum == string.Empty || sysData.compSerialNum == "ÿÿÿÿÿ")    //will get here for 6310 with intel wireless, or optiflex ydiaeresis
                {//use mac address since nothing else available
                    NetSerial();  //get Mac Address for wired LAN adapter - harder than it looks!!! - found out the hard way!!
                    sysData.compSerialNum = macAddress;
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying Baseboard or BIOS WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void NetSerial()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name,Manufacturer,PNPDeviceID,MACAddress FROM Win32_NetworkAdapter");
                ManagementObjectCollection net = searcher.Get();
                foreach (ManagementObject queryObj in net)
                {
                    if (queryObj.GetPropertyValue("MACAddress") == null)
                        continue;
                    if (queryObj.GetPropertyValue("Manufacturer") == null)
                        continue;
                    else
                    {
                        if (queryObj.GetPropertyValue("Manufacturer").ToString().ToLower() == "microsoft")
                            continue;
                    }
                    string name = queryObj.GetPropertyValue("Name").ToString();
                    name = name.ToLower();
                    if (name.Contains("bluetooth") || name.Contains("wireless") || name.Contains("wifi") || name.Contains("mobile") || name.Contains("wlan") || name.Contains("802.11"))
                        continue;
                    if (queryObj.GetPropertyValue("PNPDeviceID").ToString().Contains("ROOT"))
                        continue;
                    macAddress = queryObj.GetPropertyValue("MACAddress").ToString();
                    return;
                }
                MessageBox.Show("An Error occurred while analyzing Mac Address WMI data", "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying Net Adapter Info WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void Net()
        {
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT MACAddress FROM Win32_NetworkAdapter");
                ManagementObjectCollection net = searcher.Get();
                foreach (ManagementObject queryObj in net)
                {//memory already in place insert before
                    if (queryObj.GetPropertyValue("MACAddress") != null)
                    {
                        macAddress = queryObj.GetPropertyValue("MACAddress").ToString();
                        //Log.WritWTime("MacAddress =" + sysWmi["MACAddress"]);
                        return; //Only get first real mac address skip the rest
                    }
                }

            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying Net WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
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
                    sysData.compClockSpeed = regExpCommaFind.Replace(queryObj.GetPropertyValue("MaxClockSpeed").ToString(), "");
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
                sysData.compDiskSize = (diskSize / 1073741824).ToString();

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
                    sysData.osCaption = queryObj.GetPropertyValue("Caption").ToString().Substring(10); //Eliminiate Microsoft from the OS name
                    sysData.osVersion = queryObj.GetPropertyValue("Version").ToString();
                }
                if (Environment.OSVersion.Version.Major > 5)
                {

                    searcheros = new ManagementObjectSearcher("root\\CIMV2", "SELECT OSArchitecture FROM Win32_OperatingSystem");
                    os = searcheros.Get();
                    foreach (ManagementObject queryObj in os)
                    {
                        sysData.osWidth = queryObj.GetPropertyValue("OSArchitecture").ToString();
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An Error occurred while querying OperatingSystem WMI data: " + e.Message, "Tax-Aide Inventory Data Collection");
                Environment.Exit(0);
            }
        }
        internal void PartialKey()
        {
            if (Environment.OSVersion.Version.Major < 6)
                return;
            try
            {
                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT PartialProductKey FROM SoftwareLicensingProduct");
                ManagementObjectCollection keys = searcher.Get();
                foreach (ManagementObject queryObj in keys)
                {
                    if (queryObj.GetPropertyValue("PartialProductKey") != null)
                    {
                        sysData.osPartialKey = (string)queryObj.GetPropertyValue("PartialProductKey");
                        break;
                    }
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
                return proc.ExitCode;
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
        internal int LicInstall(string productKey)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Environment.SystemDirectory.Substring(0, 2) + "\\SyncCommands\\slmgrmine.vbs";
            proc.StartInfo.Arguments = "/ipk " + productKey;
            proc.Start();
            while (!proc.HasExited)
            {
                System.Threading.Thread.Sleep(500);
            }
            return proc.ExitCode;
        }
        void VBoxSerial()
        {
            DiskDrive();
            //at this point assume we have memory and disl size then
            sysData.compSerialNum = diskSize.ToString() + ":" + memory.ToString();
            return;
        }
        internal void GetProductKey()
        {
            RegistryKey registry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", false);
            byte[] digitalProductId = registry.GetValue("DigitalProductId") as byte[];
            sysData.osProductKey = DecodeProductKey(digitalProductId);
            if (Environment.OSVersion.Version.Major < 6)
                return;
            byte[] digitalProductId4 = registry.GetValue("DigitalProductId4") as byte[];
            sysData.osKeyType = GetString(digitalProductId4, 0x03F8);
        }
        private string DecodeProductKey(byte[] digitalProductId)
        {
            const int keyStartIndex = 52;// Offset of first byte of encoded product key in 'DigitalProductIdxxx" REG_BINARY value. Offset = 34H.
            const int keyEndIndex = keyStartIndex + 15;// Offset of last byte of encoded product key in 'DigitalProductIdxxx" REG_BINARY value. Offset = 43H.
            // Possible alpha-numeric characters in product key.
            char[] digits = new char[] { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R', 'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9', };

            const int decodeLength = 29;  // Length of decoded product key
            const int decodeStringLength = 15;  // Length of decoded product key in byte-form.  Each byte represents 2 chars.
            char[] decodedChars = new char[decodeLength];  // Array of containing the decoded product key.
            ArrayList hexPid = new ArrayList();  // Extract byte 52 to 67 inclusive.
            for (int i = keyStartIndex; i <= keyEndIndex; i++)
            {
                hexPid.Add(digitalProductId[i]);
            }
            for (int i = decodeLength - 1; i >= 0; i--)
            {
                if ((i + 1) % 6 == 0)  // Every sixth char is a separator.
                {
                    decodedChars[i] = '-';
                }
                else
                {
                    int digitMapIndex = 0;  // Do the actual decoding.
                    for (int j = decodeStringLength - 1; j >= 0; j--)
                    {
                        int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                        hexPid[j] = (byte)(byteValue / 24);
                        digitMapIndex = byteValue % 24;
                        decodedChars[i] = digits[digitMapIndex];
                    }
                }
            }
            return new string(decodedChars);
        }
        string GetString(byte[] bytes, int index)
        {
            int n = index;
            while (!(bytes[n] == 0 && bytes[n + 1] == 0)) n++;
            return Encoding.ASCII.GetString(bytes, index, n - index).Replace("\0", "");
        }
    }
}

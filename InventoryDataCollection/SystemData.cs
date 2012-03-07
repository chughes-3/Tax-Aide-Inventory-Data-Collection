using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Collections.Specialized;

namespace InventoryDataCollection
{
    public class SystemsDataMultiple : IEnumerable
    {
        public const string fileName = "\\TaxAideInv2012.xml";
        public static string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        Dictionary<string, SystemData> syssDataMultiple = new Dictionary<string, SystemData>();
        public SystemsDataMultiple()
        {// reads xml file and loads the dictionary
            if (!System.IO.File.Exists(path + fileName))
                return;
            XDocument doc = null;
            try
            {
                doc = XDocument.Load(path + fileName);
            }
            catch (Exception)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("The Existing Inventory Data File is not correctly formatted. \r\nDelete and Continue?", "Inventory Data Collection", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Delete(path + fileName);
                    return;
                }
                else
                    Environment.Exit(1);
            }
            IEnumerable<XElement> systems = doc.Root.Elements();
            foreach (XElement sysEl in systems)
            {
                if ((string)sysEl.Element(SystemData.serialNumber) != null)
                    syssDataMultiple.Add(sysEl.Element(SystemData.serialNumber).Value, new SystemData(sysEl));
            }
        }
        public void SystemDataDelete(string serial)
        {
            syssDataMultiple.Remove(serial);
        }
        public void SystemDataAdd(SystemData sysData)
        {// adds a single system(ordereddictinary data) to the Systems dictionary
            if (syssDataMultiple.ContainsKey(sysData.compSerialNum))
            {
                DialogResult result = MessageBox.Show("The Inventory Data file already contains this system.\r\nReplace previous values?", "Inventory Data Collection", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                    syssDataMultiple.Remove(sysData.compSerialNum);
                else
                    Environment.Exit(1);
            }
            syssDataMultiple.Add(sysData.compSerialNum, sysData);
        }
        public void SystemChangeAssetorSerial(string serialNum, string AssetTNew, string SerialNoHRNew)
        {
            if (AssetTNew != string.Empty)
                syssDataMultiple[serialNum].compAssetTag = AssetTNew;
            if (SerialNoHRNew != string.Empty)
                syssDataMultiple[serialNum].compSerialNumHR = SerialNoHRNew;
        }
        public XElement SystemXElement(string serialNum)
        {//gets the orderedDictionary data for a system and turns it into xml
            SystemData sysdata = syssDataMultiple[serialNum];   //gets SystemData object from dictionary 
            return sysdata.SystemXElement();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public SystemDataEnumerator GetEnumerator()
        {
            return new SystemDataEnumerator(this);
        }
        public class SystemDataEnumerator : IEnumerator
        {// This enumerator for the class simply returns the values out of the Systemsdictionary and ignores the keys
            private SystemsDataMultiple _sysSData;  //to store the object iterating over
            private Dictionary<string, SystemData>.Enumerator dictEnum; // we are returning the values from this private dictionary as the enumeration for this class
            private int currIndex;
            private SystemData currSystemData;

            public SystemDataEnumerator(SystemsDataMultiple sysSData)
            {
                _sysSData = sysSData;
                dictEnum = _sysSData.syssDataMultiple.GetEnumerator();
                currIndex = -1;
            }
            public bool MoveNext()
            {
                if (++currIndex >= _sysSData.syssDataMultiple.Count)
                {
                    return false;
                }
                else
                {//set the currindex to next item in dictionary
                    dictEnum.MoveNext();
                    currSystemData = dictEnum.Current.Value;
                }
                return true;
            }
            public void Reset() { currIndex = -1; }
            public SystemData Current
            {
                get { return currSystemData; }
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
    public class SystemData
    {


        #region Class Constant definitions ie some, but not all of the inventory spreadsheet column headings
        const string assetTag = "Asset_Tag";
        const string clockSpeed = "Processor_Speed";
        const string memory = "Memory";
        const string diskSize = "Hard_Drive_Size";
        const string name = "Computer_Name";
        const string manufacturer = "MR_Manufacturer";
        const string model = "MR_Model";
        public const string serialNumber = "MR_Serial_Number";  // this needed by multiple system data class
        const string serialNumberHR = "Mfg_Serial_Number";
        const string caption = "OS_Name";
        const string version = "OS_Version";
        const string width = "OS_Width";
        const string keyType = "OS_Product_Key_Type";
        const string partialKey = "OS_Partial_Product_Key";
        const string productKey = "OS_Product_Key";
        #endregion

#region System Data Ordered Dictionary definition, this sets data field order in XML file.Named Const fields used elsewhere in program
        OrderedDictionary sysData = new OrderedDictionary()
            {//Setup dictionary entries and therfore order of inventory data fields in XML file, named fields used in program. Non named are ther to fill out spreadsheet

		        {"State", ""},
                {assetTag , String.Empty},
                {"Category", String.Empty},
                {"Provider", String.Empty},
                {"Mfg_ID", String.Empty},
                {"Mfg_Model", String.Empty},
                {serialNumberHR, String.Empty},
                {"Mfg_Date", String.Empty},
                {"Status", String.Empty},
                {clockSpeed, String.Empty},
                {memory, String.Empty},
                {diskSize, String.Empty},
                {"Notes", String.Empty},
                {"Custodial_Vol_ID", String.Empty},
                {"Custodian", String.Empty},
                {name, String.Empty},
                {manufacturer, String.Empty},
                {model, String.Empty},
                {serialNumber, String.Empty},
                {caption, String.Empty},
                {version, String.Empty},
                {width, String.Empty},
                {keyType, String.Empty},
                {partialKey, String.Empty},
                {productKey, String.Empty}
 
            };
#endregion

        #region Class property declarations
        public string compSerialNum
        {
            get { return sysData[serialNumber].ToString(); }
            set { sysData[serialNumber] = value; }
        }
        public string compSerialNumHR
        {
            get { return sysData[serialNumberHR].ToString(); }
            set { sysData[serialNumberHR] = value; }
        }
        public string compName
        {
            get { return sysData[name].ToString(); }
            set { sysData[name] = value; }
        }
        public string compModel
        {
            get { return sysData[model].ToString(); }
            set { sysData[model] = value; }
        }
        public string compManufacturer
        {
            get { return sysData[manufacturer].ToString(); }
            set { sysData[manufacturer] = value; }
        }
        public string compMemory
        {
            get { return sysData[memory].ToString(); }
            set { sysData[memory] = value; }
        }
        public string compClockSpeed
        {
            get { return sysData[clockSpeed].ToString(); }
            set { sysData[clockSpeed] = value; }
        }
        public string compDiskSize
        {
            get { return sysData[diskSize].ToString(); }
            set { sysData[diskSize] = value; }
        }
        public string compAssetTag
        {
            get { return sysData[assetTag].ToString(); }
            set { sysData[assetTag] = value; }
        }
        public string osCaption
        {
            get { return sysData[caption].ToString(); }
            set { sysData[caption] = value; }
        }
        public string osVersion
        {
            get { return sysData[version].ToString(); }
            set { sysData[version] = value; }
        }
        public string osWidth
        {
            get { return sysData[width].ToString(); }
            set { sysData[width] = value; }
        }
        public string osKeyType
        {
            get { return sysData[keyType].ToString(); }
            set { sysData[keyType] = value; }
        }
        public string osPartialKey
        {
            get { return sysData[partialKey].ToString(); }
            set { sysData[partialKey] = value; }
        }
        public string osProductKey
        {
            get { return sysData[productKey].ToString(); }
            set { sysData[productKey] = value; }
        }

        #endregion

        public SystemData(XElement el)
        {//loads dictionary from an xml element
            IEnumerable<XElement> system = el.Elements();
            foreach (XElement item in system)
            {//Needs test for name existence and message box in case file corruptedby user
                sysData[item.Name.ToString()] = item.Value;
            }
        }
        public SystemData()
        {//loads dictionary with relevant WMI data about system upon which executing
            WMI wmi = new WMI(this);
            wmi.ComputerSystem();
            wmi.BiosMotherBoard();  //builds manufacturer serial number fields Adds the lines to listbox in method
            wmi.Proc();
            wmi.DiskDrive();
            wmi.OS();
            wmi.PartialKey();
            wmi.GetProductKey();
        }
        public int count
        {
            get { return sysData.Count; }
        }
        public XElement SystemXElement()
        {
            XElement system = new XElement("system");
            System.Collections.IDictionaryEnumerator myEnumerator = sysData.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                system.Add(new XElement(myEnumerator.Key.ToString(), myEnumerator.Value));
            }
            return system;
        }
        public void Save2File(string filename)
        {
            XElement system = new XElement("system");
            System.Collections.IDictionaryEnumerator myEnumerator = sysData.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                system.Add(new XElement(myEnumerator.Key.ToString(), myEnumerator.Value));
            }
            system.Save("dict.xml");
        }
    }
}

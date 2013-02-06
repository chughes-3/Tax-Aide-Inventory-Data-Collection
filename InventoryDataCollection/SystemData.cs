using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Specialized;

namespace InventoryDataCollection
{
    public class SystemData
    {

        #region Class Constant definitions ie some, but not all of the inventory spreadsheet column headings
        const string assetTag = "asset_tag";
        const string clockSpeed = "processor_speed";
        const string memory = "memory";
        const string diskSize = "hard_drive_size";
        const string name = "computer_name";
        const string manufacturer = "mr_manufacturer";
        const string model = "mr_model";
        public const string serialNumber = "mr_serial_number";  // this needed by multiple system data class
        const string manufacturerHR = "mfg_id";
        const string serialNumberHR = "mfg_serial_number";
        const string caption = "os_name";
        const string version = "os_version";
        const string width = "os_width";
        const string keyType = "os_product_key_type";
        const string partialKey = "os_partial_product_key";
        const string productKey = "os_product_key";
        const string LAC_Mac = "lac_mac";
        const string LAC_Name = "lac_name";
        const string distNum = "district_number";
        #endregion

        #region System Data Ordered Dictionary definition, this sets data field order in XML file.Named Const fields used elsewhere in program
        OrderedDictionary sysData = new OrderedDictionary()
            {//Setup dictionary entries and therfore order of inventory data fields in XML file, named fields used in program. Non named are ther to fill out spreadsheet

                {distNum , String.Empty},
		        {"state", ""},
                {assetTag , String.Empty},
                {"category", String.Empty},
                {"provider", String.Empty},
                {manufacturerHR, String.Empty},
                {"mfg_model", String.Empty},
                {serialNumberHR, String.Empty},
                {"mfg_date", String.Empty},
                {"status", String.Empty},
                {clockSpeed, String.Empty},
                {memory, String.Empty},
                {diskSize, String.Empty},
                {"notes", String.Empty},
                {"custodial_vol_id", String.Empty},
                {"custodian", String.Empty},
                {name, String.Empty},
                {manufacturer, String.Empty},
                {model, String.Empty},
                {serialNumber, String.Empty},
                {caption, String.Empty},
                {version, String.Empty},
                {width, String.Empty},
                {keyType, String.Empty},
                {partialKey, String.Empty},
                {productKey, String.Empty},
                {LAC_Mac, String.Empty},
                {LAC_Name, String.Empty}
 
            };
        #endregion

        #region Field list for those fields that are saved from prior year and copied into current year
        List<string> hrFields = new List<string>()
        {
		        "state",
                assetTag , 
                "category",
                "provider",
                manufacturerHR, 
                "mfg_model",
                serialNumberHR, 
                "mfg_date",
                "status",
                "notes",
                "custodial_vol_id",
                "custodian"
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
        public string compManufacturerHR
        {
            get { return sysData[compManufacturerHR].ToString(); }
            set { sysData[manufacturerHR] = value; }
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
        public string compLAC_Mac
        {
            get { return sysData[LAC_Mac].ToString(); }
            set { sysData[LAC_Mac] = value; }
        }
        public string compLAC_Name
        {
            get { return sysData[LAC_Name].ToString(); }
            set { sysData[LAC_Name] = value; }
        }
        public string distNumb
        {
            get { return sysData[distNum].ToString(); }
            set { sysData[distNum] = value; }
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
            Log.WritWTime("SystemData Class Initializer, Starting WMI");
            WMI wmi = new WMI(this);
            wmi.ComputerSystem();
            wmi.NetSerial();    //sets up mac address and records it. The value may be used by BiosMotherboard below
            wmi.BiosMotherBoard();  //builds manufacturer serial number fields Adds the lines to listbox in method
            wmi.Proc();
            wmi.DiskDrive();
            wmi.OS();
            wmi.PartialKey();
            if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 1)   //only get keys for Win 7
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

        internal void GetHRData()
        {
            XElement xDataPrev = null;
            XElement xDatathisSysHRdnLoad = null;
            XElement xDataThisSysIDCPrev = null;
            HrDataPrevDisparity dataDisparityForm = new HrDataPrevDisparity();
            string filePrevPath = System.IO.Path.Combine(Start.path, Start.fileNameInvDBdnload);
            if (System.IO.File.Exists(filePrevPath))
            {
                try
                {
                    xDataPrev = XElement.Load(filePrevPath);
                }
                catch (Exception)
                {
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("The Inventory Download File is not correctly formatted. \r\nDelete and Continue?", "Inventory Data Collection", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.Delete(filePrevPath);
                        return;
                    }
                    else
                        Environment.Exit(1);
                }
                xDatathisSysHRdnLoad = xDataPrev.Elements("system").FirstOrDefault(el => el.Element("mr_serial_number").Value == this.compSerialNum);
                if (xDatathisSysHRdnLoad != null)
                {
                    dataDisparityForm.txtBxDbSn.Text = xDatathisSysHRdnLoad.Element("mfg_serial_number").Value;
                    dataDisparityForm.txtBxAtagDB.Text = xDatathisSysHRdnLoad.Element("asset_tag").Value;
                }
                else
                {
                    //80% of time mr_serial = Hr serial
                    xDatathisSysHRdnLoad = xDataPrev.Elements("system").FirstOrDefault(el => el.Element("mfg_serial_number").Value == this.compSerialNum);
                    if (xDatathisSysHRdnLoad != null)
                    {
                        dataDisparityForm.txtBxDbSn.Text = xDatathisSysHRdnLoad.Element("mfg_serial_number").Value;
                        dataDisparityForm.txtBxAtagDB.Text = xDatathisSysHRdnLoad.Element("asset_tag").Value;
                    }
                }
            }
            filePrevPath = System.IO.Path.Combine(Start.path, Start.fileNamePrevEir);
            if (!System.IO.File.Exists(filePrevPath))   //if prior yr EIR based file exists it ignores prior yr xml file
                filePrevPath = System.IO.Path.Combine(Start.path, Start.fileNamePrevVer);
            if (System.IO.File.Exists(filePrevPath))
            {
                xDataPrev = XElement.Load(filePrevPath);
                // Lower casing field names could also be done with regex as in
                // Regex.Replace( xml, @"<[^<>]+>", m => { return m.Value.ToLower(); }, RegexOptions.Multiline | RegexOptions.Singleline);
                // this requires using a streamreader or some other method of getting teh xelement to a string
                var xDataPrevCollection = xDataPrev.Elements("system").Select(elsys => new XElement("system", elsys.Elements().Select(fld => new XElement(fld.Name.ToString().ToLower(), fld.Value))));  //get all field names to lower case
                //At this point we have a collection of XElements each labeled system, we do NOT have the higher level "systems" XElement anymore and since we just need to do another Linq statement we do not need to cast the collection back to an XElement.
                xDataThisSysIDCPrev = xDataPrevCollection.FirstOrDefault(el => el.Element("mr_serial_number") == null ? false : el.Element("mr_serial_number").Value == this.compSerialNum);
                if (xDataThisSysIDCPrev != null)
                {
                    //just load all the hr fields here with trim and then do the 2 statement belwo from the dictionary
                    //hrFields.Select(fld => { sysData[fld] = (string)xDataThisSysIDCPrev.Element(fld); return sysData[fld]; });
                    foreach (var item in hrFields)
                    {
                        sysData[item] = (string)xDataThisSysIDCPrev.Element(item);
                    }
                    //string str = "";
                    //for (int i = 0; i < sysData.Count; i++ )
                    //{
                    //    if (sysData[i] != null)
                    //    {
                    //        str += sysData[i].ToString() + "\r\n"; 
                    //    }
                    //}
                    //System.Windows.Forms.MessageBox.Show(str);
                    dataDisparityForm.txtBxIDCPrvSn.Text = xDataThisSysIDCPrev.Element("mfg_serial_number") != null ? xDataThisSysIDCPrev.Element("mfg_serial_number").Value : string.Empty;
                    dataDisparityForm.txtBxATagIDC.Text = xDataThisSysIDCPrev.Element("asset_tag") != null ? xDataThisSysIDCPrev.Element("asset_tag").Value : string.Empty;
                }
            }
            //next check data disparities & set radio buttons on form
            dataDisparityForm.SetRadButtons();
            //at this point have radio buttons set and have shown user dialog if necessary so set data
            if (dataDisparityForm.radButAtagDB.Checked == true)
                compAssetTag = dataDisparityForm.txtBxAtagDB.Text;
            else
                compAssetTag = dataDisparityForm.txtBxATagIDC.Text;
            if (dataDisparityForm.radButSnDb.Checked == true)
            {
                compSerialNumHR = dataDisparityForm.txtBxDbSn.Text;
                if (xDatathisSysHRdnLoad.Element("mfg_id").Value != string.Empty)
                    compManufacturerHR = xDatathisSysHRdnLoad.Element("mfg_id").Value;
                else
                    if (xDataThisSysIDCPrev != null)
                        compManufacturerHR = xDataThisSysIDCPrev.Element("mfg_id").Value;
            }
            else
            {
                compSerialNumHR = dataDisparityForm.txtBxIDCPrvSn.Text;
                if (xDataThisSysIDCPrev != null && xDataThisSysIDCPrev.Element("mfg_id").Value != String.Empty)
                    compManufacturerHR = xDataThisSysIDCPrev.Element("mfg_id").Value;
                else
                    if (xDatathisSysHRdnLoad != null)
                        compManufacturerHR = xDatathisSysHRdnLoad.Element("mfg_id").Value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace InventoryDataCollection
{
    public class SystemsDataMultiple : IEnumerable
    {
        Dictionary<string, SystemData> syssDataMultiple = new Dictionary<string, SystemData>();
        public int filePrevVerPres = 0;
        public SystemsDataMultiple()
        {// reads xml file and loads the dictionary
            XElement xmlSystems = null;
            string file = System.IO.Path.Combine(Start.path, Start.fileName);
            if (!System.IO.File.Exists(file))
                return;
            try
            {
                xmlSystems =XElement.Load(file);
            }
            catch (Exception)
            {
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("The Existing Inventory Data File is not correctly formatted. \r\nDelete and Continue?", "Inventory Data Collection", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Error, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.File.Delete(file);
                    return;
                }
                else
                    Environment.Exit(1);
            }
            foreach (XElement sysEl in xmlSystems.Elements("system"))
            {//for 2013 the xml field defn are all lower case whereas field and Column names are mixed case in prior yr and early 13. Make all lower case.
                XElement sysElLower = new XElement("system", sysEl.Elements().Select(el => new XElement(el.Name.ToString().ToLower(), el.Value)));
                if ((string)sysElLower.Element(SystemData.serialNumber) != null)
                    syssDataMultiple.Add(sysElLower.Element(SystemData.serialNumber).Value, new SystemData(sysElLower));
            }
            Log.WritWTime("SystemsDataMultiple: File Read in completed");
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
        public void SystemChangeAsset(string serialNum, string AssetTNew)
        {
            syssDataMultiple[serialNum].compAssetTag = AssetTNew;
        }
        public void SystemChangeSerial(string serialNum, string SerialNoHRNew)
        {
            syssDataMultiple[serialNum].compSerialNumHR = SerialNoHRNew;
        }
        public XElement SystemXElement(string serialNum)
        {//gets the orderedDictionary data for a system and turns it into xml
            SystemData sysdata = syssDataMultiple[serialNum];   //gets SystemData object from dictionary 
            return sysdata.SystemXElement();
        }
        public string GetDistnum()
        {
            var dN = syssDataMultiple.FirstOrDefault(s => s.Value.distNumb != string.Empty );
            if (dN.Value == null)
                return string.Empty;
            else
            {
                var kv = syssDataMultiple.FirstOrDefault(s => s.Value.distNumb == string.Empty);
                if (kv.Value == null)   //ie we have the district number in all entries
                    return dN.Value.distNumb;
                else
                {
                    //Update any empty district numbers with the found district number
                    //var kvs = syssDataMultiple.Where(s=> s.Value.distNumb == string.Empty).Select(kvi => syssDataMultiple[kvi.Key].distNumb = dN.Value.distNumb);
                    var kvs = syssDataMultiple.Where(s => s.Value.distNumb == string.Empty);
                    foreach (var item in kvs)
                    {
                        syssDataMultiple[item.Key].distNumb = dN.Value.distNumb;
                    }
                    return dN.Value.distNumb;
                }
            }
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
}

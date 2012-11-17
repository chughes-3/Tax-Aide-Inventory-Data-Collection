using System;
using System.Windows.Forms;
using System.IO;

namespace InventoryDataCollection
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// The data structure and field names that capture the inventory spreadsheet format are in the SystemData File SystemData Class
        /// The  Inventory Data file name is in SystemData File SystemData Class
        /// Column name strings for the SysDsplyForm MUST be same as exposed property names of SystemData class. The form Column order is defined in form code not form designer
        /// An instance of the SystemsDataMultiple Class is created. During instance initialization the existing XML file is read
        /// Existing XML file is read in and each system entry is stored in an entry in the SystemsDataMultiple dictionary. See SystemData File.
        /// SystemsDataMultiple data storage structure is a dictionary (key = MRSerialNumber, Value is SystemData object) 
        /// The SystemData object is an ordered dictionary (key = data Name, value = data value eg key = compmemory, value =2000). The order = order in spreadsheet
        /// The form display and data output is done off the data storage dictionaries
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime endDemo = new DateTime(2013, 1, 31);
            if (endDemo < DateTime.Now)
            {
                MessageBox.Show("This program is a draft version intended for use before the 2013 Tax-Aide Inventory reporting activity.\r\nIt is likely that a new program version will be created for the 2013 Inventory Reporting.\r\nTherefore this version stopped working in Feb 2013.\r\n\r\nQuestions? Please contact your TCS or TaxAideTech","AARP Foundation Tax-Aide");
                Environment.Exit(0);
            }
            //Log debugLog = new Log(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TAInvLog.log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SysDsplyForm());
        }
    }
}

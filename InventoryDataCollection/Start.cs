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
        /// The  Inventory Data file name is in SystemData File MultipleSystemsData Class
        /// Column names for this form MUST be same as exposed properties of SystemData class that should be displayed. the Column order and is defined in form code
        /// Structure is a dictionary (key = MRSerialNumber, Value is SystemData object) 
        /// The SystemData object is an ordered dictionary (key = data Name, value = data value eg key = compmemory, value =2000). The order = order in spreadsheet
        /// The form display and data output is done off the data storage dictionaries
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime endDemo = new DateTime(2012, 2, 1);
            if (endDemo < DateTime.Now)
            {
                MessageBox.Show("This is a Demonstration Program whose Time Limit has expired\r\nPlease download the latest version and use that version.");
                Environment.Exit(0);
            }
            //Log debugLog = new Log(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TAInvLog.log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SysDsplyForm());
        }
    }
}

using System;
using System.Windows.Forms;
using System.IO;

namespace InventoryDataCollection
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
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
            Application.Run(new Form1());
        }
    }
}

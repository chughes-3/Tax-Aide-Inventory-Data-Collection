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
            //Log debugLog = new Log(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TAInvLog.log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

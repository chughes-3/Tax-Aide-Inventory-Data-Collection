using System;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace InventoryDataCollection
{
    static class Start
    {
        /// <summary>
        /// The main entry point for the application.
        /// The data structure and field names that capture the inventory spreadsheet format are in the SystemData File SystemData Class
        /// Column name strings for the SysDsplyForm MUST be same as exposed property names of SystemData class. The form Column order is defined in form code not form designer
        /// An instance of the SystemsDataMultiple Class is created. During instance initialization the existing XML file is read
        /// Existing XML file is read in and each system entry is stored in an entry in the SystemsDataMultiple dictionary. See SystemData File.
        /// SystemsDataMultiple data storage structure is a dictionary (key = MRSerialNumber, Value is SystemData object) 
        /// The SystemData object is an ordered dictionary (key = data Name, value = data value eg key = compmemory, value =2000). The order = order in spreadsheet
        /// The form display and data output is done off the data storage dictionaries
        /// </summary>

        public const string fileName = "TaxAideInv2013.xml";
        public const string xmlFileRev = "IDC XML Version 2013.03"; //put here to synchronize with file name used in Form Closes comment string in xml file output
        public const string fileNameInvDBdnload = "MrHrLink4IDC2013.xml";  //Used by SystemData class but here to put all strings in same place
        public const string fileNamePrevVer = "TaxAideInv2012.xml";
        public const string fileNamePrevEir = "TaxAideInvEIR2012.xml";
        public static string path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        public static string mbCaption = "Tax-Aide Inventory Data Collection";

        [STAThread]
        static void Main()
        {
            DateTime endDate = new DateTime(2013, 11, 15);
#if Log
            endDemo = DateTime.Now.AddDays(14);     
#endif
            if (endDate < DateTime.Now)
            {
#if Log
                MessageBox.Show("This is a debug version whose timer has expired. \r\nPlease delete this version", "AARP Foundation TaxAide");
                Environment.Exit(1);
#endif
                MessageBox.Show("This program version is intended for use in the 2013 Tax-Aide Inventory reporting activity.\r\nTherefore this version stopped working in November 2013.\r\n\r\nQuestions? Please contact your TCS or TaxAideTech", "AARP Foundation Tax-Aide");
                Environment.Exit(0);
            }
            Log debugLog = new Log(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\TaIDCLog.log");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TestPriorYrFiles();
            Application.Run(new SysDsplyForm());
        }

        private static void TestPriorYrFiles()
        {
            if (File.Exists(Path.Combine(path, fileNamePrevVer)) || File.Exists(Path.Combine(path,fileNamePrevEir)))
            {
                if (File.Exists(Path.Combine(path, fileNameInvDBdnload)))
                    return;
                else
                {
                    Log.WritW("TaIdcXMl or TaIdcEIR Prev exists, DBdnload not exist");
                    if (!InternetPresent())
                    {
                        Log.WritW("No Internet");
                        DialogResult diagResp = MessageBox.Show("The download file from the National Inventory database is not present.\r\n This file allows automatic entry of many fields that would otherwise have to be typed.\r\nIn order to obtain it connect this system to the Internet and restart this program. \r\n\r\nExit to allow internet connection?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (diagResp == DialogResult.Yes)
                            Environment.Exit(0);
                        else
                            return;
                    }
                    else
                    {
                        Log.WritW("Internet Present");
                        DialogResult diagResp = MessageBox.Show("The download file from the National Inventory database is not present.\r\n This file allows automatic entry of many fields that would otherwise have to be typed.\r\nThis system has an Internet connection. \r\n\r\nObtain the file now?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (diagResp == DialogResult.Yes)
                            ObtainDbDnLoad();
                        return;
                    }
                }
            }
            else
            {
                if (File.Exists(Path.Combine(path, fileNameInvDBdnload)))
                {
                    Log.WritW("TaIdcXML prev does NOT exist, DBdnload does exist");
                    DialogResult diagResp = MessageBox.Show("A file containing last year's IDC data (either last year's IDC file or a file generated from EIR2012) does not exist in the same directory as this program.\r\nThis file allows additional data checking above and beyond the file downloaded from the National Database.\r\nIt is recommended that the program be exited and the file obtained. \r\n\r\nExit the program?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (diagResp == DialogResult.Yes)
                        Environment.Exit(1);
                    else
                        return;
                }
                else
                {
                    if (InternetPresent())
                    {
                        Log.WritW("Neither file exists, Internet exists");
                        DialogResult diagResp = MessageBox.Show("It is recommended that a file containing last year's IDC data (either last year's IDC file or a file generated from EIR2012) and/or the State's download file from the National Inventory database be present in the same directory as this program.\r\n These files allow automatic entry of many fields that would otherwise have to be typed.\r\nThis system has an Internet connection. \r\n\r\nThis program can download a file. Obtain the file now?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (diagResp == DialogResult.Yes)
                            ObtainDbDnLoad();
                        diagResp = MessageBox.Show("It is recommended that a file containing last year's IDC data (either last year's IDC file or a file generated from EIR2012) be in the same directory as this program.\r\n This file allows additional data checking above and beyond the file downloaded fromt the National Database.\r\nIt is recommended that the program be exited and the file obtained. \r\n\r\nExit the program?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (diagResp == DialogResult.Yes)
                            Environment.Exit(0);
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Log.WritW("Neither file exists, No Internet");
                        DialogResult diagResp = MessageBox.Show("The download file from the National Inventory database is not present.\r\n This file allows automatic entry of many fields that would otherwise have to be typed.\r\nIn order to obtain it connect this system to the Internet and restart this program. \r\n\r\nExit to allow internet connection?", mbCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (diagResp == DialogResult.Yes)
                            Environment.Exit(0);
                        else
                            return;
                    }
                }
            }
        }

        private static void ObtainDbDnLoad()
        {

            string URI = "http://www.taxaideaarp.org/NLKAccess/mrhrlink/stateHrMrlnk.php";
            string param = "state=";
            ChooseSplitState ss = new ChooseSplitState();
            ss.ShowDialog();    //ss.splitState = css code
            param += ss.splitState;
            System.Threading.Thread pBar = new System.Threading.Thread(() => new Progress().Show());
            pBar.Start();
            using (WebClient webclient = new WebClient())
            {
                webclient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = webclient.UploadString(URI, param);
                File.WriteAllText(Path.Combine(path, fileNameInvDBdnload), HtmlResult);
            }
            pBar.Abort();
        }

        private static bool InternetPresent()
        {
            try
            {
                string myAddress = "www.google.com";
                IPAddress[] addresslist = Dns.GetHostAddresses(myAddress);
                if (addresslist[0].ToString().Length > 6)
                {
                    return true;
                }
                else
                    return false;

            }
            catch
            {
                return false;
            }

        }
    }
}

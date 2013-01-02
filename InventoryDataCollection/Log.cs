using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace InventoryDataCollection
{
    public class Log
    {
        public static StreamWriter WriteStrm; //declared as static so only 1 instance so get at it via class not object
        public static string logPathFile;
        public Log(string str)
        {
#if Log
            WriteStrm = new StreamWriter(str,true);
#else
            WriteStrm = StreamWriter.Null;
#endif
            logPathFile = str;
            WriteStrm.WriteLine("***");
            WriteStrm.WriteLine("***");
            WriteStrm.WriteLine("***");
            WriteStrm.WriteLine("            AARP Tax-Aide Log Startup: " + DateTime.Now.ToString());
            WriteStrm.Flush();
        }
        public static void WritW(string str)//declare as static so that can access via class ie the instantiated object name is never used in this class.
        {
            WriteStrm.WriteLine(str);
            WriteStrm.Flush();
        }
        public static void WriteStr(string str)
        {
            WriteStrm.Write(str);
            WriteStrm.Flush();
        }
        public static void WritWTime(string str)//declare as static so that can access via class ie the instantiated object name is never used in this class.
        {
            WriteStrm.WriteLine(DateTime.Now.ToLongTimeString() + ": " + str);
            WriteStrm.Flush(); 
        }
        public static void WritSection(string str)// puts in space before writing.
        {
            WriteStrm.WriteLine(" ");
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            System.Reflection.MethodBase methodBase = stackFrame.GetMethod();
            //string str1 = System.Reflection.MethodInfo.GetCurrentMethod().Name;
            WriteStrm.WriteLine("Method Name = " + methodBase.Name);
            WriteStrm.WriteLine(DateTime.Now.ToLongTimeString() + ": " + str);
        }
    }
}

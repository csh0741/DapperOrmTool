using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DapperDataObjectLib
{
    public static class WriteLogExtension
    {
        public static void SetLogs(string _exception, string cmdstr = "")
        {
            string sFileName = string.Format("{0:yyyyMMdd}.txt", DateTime.Now);
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "System_Log\\" + sFileName;
            StreamWriter oSw = null;
            try
            {
                oSw = File.AppendText(sPath);
                oSw.Write(DateTime.Now.ToString("HH:mm:ss")+" >> ");
                oSw.WriteLine(cmdstr);
                if (_exception != "")
                {
                    oSw.Write(DateTime.Now.ToString("HH:mm:ss") + " >> ");
                    oSw.WriteLine(_exception);
                }
                
            }
            catch (Exception e)
            {
            }
            if (oSw != null)
                oSw.Dispose();
        }//end method



        public static void SetLogs(this OrmDataObject odo, string cmdstr = "")
        {
            string sFileName = string.Format("{0:yyyyMMdd}.txt", DateTime.Now);
            string sPath = System.AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "System_Log\\" + sFileName;
            StreamWriter oSw = null;
            try
            {
                oSw = File.AppendText(sPath);
                oSw.Write(DateTime.Now.ToString("HH:mm:ss") + " >> ");
                oSw.WriteLine(cmdstr);
                oSw.Write(DateTime.Now.ToString("HH:mm:ss") + " >> ");
                oSw.WriteLine(odo.DbExceptionMessage);
            }
            catch (Exception e)
            {
            }
            if (oSw != null)
                oSw.Dispose();
        }//end method


    }//end log class

}//end namespace

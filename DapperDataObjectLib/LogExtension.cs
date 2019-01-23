using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperDataObjectLib;
using System.IO;

namespace DapperDataObjectLib
{
    public static class LogExtension
    {

        public static void SetLogs(this OrmDataObject odo, string cmdstr = "")
        {
            if (!odo.isSuccess || odo.DbExceptionMessage.Length > 0)
            {
                string sFileName = string.Format("{0:yyyyMMdd}.txt", DateTime.Now);
                string sPath = System.AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "SystemLog\\" + sFileName;
                StreamWriter oSw = null;
                try
                {
                    oSw = File.AppendText(sPath);
                    oSw.WriteLine(cmdstr);
                    oSw.WriteLine(odo.DbExceptionMessage);
                }
                catch (Exception e)
                {
                }
                if (oSw != null)
                    oSw.Dispose();
            }
        }//end method



    }//end Extension class
}//end namespace

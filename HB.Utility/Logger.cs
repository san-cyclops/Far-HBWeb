using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Utility
{
    public static class Logger
    {

        public static string debugFile = string.Empty;
        public static string debugFilePath = @"C:\LOG\";

        public enum logtype
        {
            Event,
            ErrorLog
        }

        public static void SetPathLog(string path)
        {
            if (String.IsNullOrEmpty(path))
                debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);

            else
                debugFilePath = path;

        }



        public static void WriteLog(Exception log, string methodName, string formName = "Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {
            // No path

            try
            {
                if (debugFilePath == string.Empty)
                    debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);


                string tmpdebugFilePath;
                switch (LogType)
                {
                    case logtype.ErrorLog:
                        var lineNumber = new System.Diagnostics.StackTrace(log, true).GetFrame(0).GetFileLineNumber();
                        tmpdebugFilePath = debugFilePath + "Error.log";
                        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " +"| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Message.ToString().Trim() + "\r\n" + lineNumber.ToString() + "\r\n");
                         
                        break;
                    case logtype.Event:
                        tmpdebugFilePath = debugFilePath + @"\Events";
                        bool isExists = System.IO.Directory.Exists(tmpdebugFilePath);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(tmpdebugFilePath);
                        tmpdebugFilePath = debugFilePath + @"\Events\Event-" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
                        System.IO.File.AppendAllText(@tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " +  "| Location : " + LocationID.ToString() + "| Event Source : " + methodName.Trim() + "| Event Name : " + formName.Trim() + "| Event : " + log.Message.ToString().Trim() + "\r\n");
                        break;
                    default:
                        tmpdebugFilePath = debugFilePath + "Error.log";
                        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " + "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Message.ToString().Trim() + "\r\n");

                        break;
                }




            }
            catch (Exception exc)
            {

            }
        }

        public static void WriteLog(string log, string methodName, string formName = "Default", logtype LogType = logtype.ErrorLog, long LocationID = 1)
        {
            // No path

            try
            {
                if (debugFilePath == string.Empty)
                    debugFilePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);


                string tmpdebugFilePath;
                switch (LogType)
                {
                    case logtype.ErrorLog:
                        tmpdebugFilePath = debugFilePath + "Error.log";
                        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " +   "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Trim() + "\r\n");
                       

                        break;
                    case logtype.Event:
                        tmpdebugFilePath = debugFilePath + @"\Events";
                        bool isExists = System.IO.Directory.Exists(tmpdebugFilePath);
                        if (!isExists)
                            System.IO.Directory.CreateDirectory(tmpdebugFilePath);
                        tmpdebugFilePath = debugFilePath + @"\Events\Event-" + DateTime.Now.ToString("dd-MM-yyyy") + ".log";
                        System.IO.File.AppendAllText(@tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " +   "| Location : " + LocationID.ToString() + "| Event Source : " + methodName.Trim() + "| Event Name : " + formName.Trim() + "| Event : " + log.Trim() + "\r\n");
                        break;
                    default:
                        tmpdebugFilePath = debugFilePath + "Error.log";
                        System.IO.File.AppendAllText(tmpdebugFilePath, "Date Time : [" + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "] " + "| Version : " +   "| Location : " + LocationID.ToString() + "| Error Source : " + methodName.Trim() + "| Form Name : " + formName.Trim() + "| Error : " + log.Trim() + "\r\n");

                        break;
                }




            }
            catch (Exception exc)
            {

            }

        }
    }
}

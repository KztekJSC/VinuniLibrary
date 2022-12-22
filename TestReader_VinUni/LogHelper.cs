using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;

namespace GeneralTool
{
    public class LogHelper
    {
        //Multy Thread Excecute
        private static object lockObject = new object();
        public static string SaveLogFolder = "";
        #region: LOG
        public static void LogUser( string message, string startUpPath, EM_LogType logType = EM_LogType.CustomerLog, int limitLength = 0)
        {
            string InitPath = GetSavePath(logType, startUpPath);
            string content = GetUserLogContent(logType, message);
            lock (lockObject)
            {
                try
                {
                    Directory.CreateDirectory(InitPath);
                    string pathFile = Path.GetDirectoryName(InitPath) + @"\" + logType.ToString() + ".html";
                    using (StreamWriter writer = new StreamWriter(pathFile, true))
                    {
                        try
                        {
                            writer.WriteLine(content);
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                }
            }

        }


        public static void Log(EM_LogType logType, string message, string startUpPath, int limitLength = 0)
        {
            string InitPath = GetSavePath(logType, startUpPath);
            string content = GetLogContent(logType, message);
            lock (lockObject)
            {
                try
                {
                    Directory.CreateDirectory(InitPath);
                    string pathFile = Path.GetDirectoryName(InitPath) + @"\" + logType.ToString() + ".html";
                    using (StreamWriter writer = new StreamWriter(pathFile, true))
                    {
                        try
                        {
                            writer.WriteLine(content);
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                }
            }

        }

        public static string GetSavePath(EM_LogType logType, string startUpPath)
        {
            string initPath = startUpPath + $@"\logs\{DateTime.Now.Month}\{DateTime.Now.Day}\";
            return initPath + logType.ToString() + @"\";
        }

        public static string GetLogContent(EM_LogType logType, string message)
        {
            string color = GetDisplayColor(logType);
            FunctionExcecute functionExcecute = GetFunctionExcecute();

            string content = $"<b style=\"color: {color}; \">{logType.ToString()}</b>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}<br>" +
                               $"<b> Function Name </b>: {functionExcecute.FunctionName}<br>" +
                               $"<b> File Name </b>: {functionExcecute.FileName}<br>" +
                               $"<b> Line Number </b>: {functionExcecute.LineNumber}<br>" +
                               $"<b style=\"color: {color}; \">Message: </b>{message}" +
                               "<hr style=\"border: none; border-top:1px dashed #f00;color:black;background-color:#fff;height:1px;width:50%;\"><br>";
            //string content = logType.ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") +
            //                 "\r\n <b>Function Name: " + functionExcecute.FunctionName +
            //                 "\r\n File Name: " + functionExcecute.FileName +
            //                 "\r\n Line Number: " + functionExcecute.LineNumber +
            //                 "\r\n Message: " + message +
            //                 "\r\n ---------------------------------------------------------------" +
            //                 "\r\n ";
            return content;
        }

        public static string GetUserLogContent(EM_LogType logType, string message)
        {
            string color = GetDisplayColor(logType);
            FunctionExcecute functionExcecute = GetFunctionExcecute();

            string content = $"<b style=\"color: {color}; \">{logType.ToString()}</b>{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}<br>" +
                               $"<b style=\"color: {color}; \">Message: </b>{message}" +
                               "<hr style=\"border: none; border-top:1px dashed #f00;color:black;background-color:#fff;height:1px;width:50%;\"><br>";
            //string content = logType.ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") +
            //                 "\r\n <b>Function Name: " + functionExcecute.FunctionName +
            //                 "\r\n File Name: " + functionExcecute.FileName +
            //                 "\r\n Line Number: " + functionExcecute.LineNumber +
            //                 "\r\n Message: " + message +
            //                 "\r\n ---------------------------------------------------------------" +
            //                 "\r\n ";
            return content;
        }



        private static string GetDisplayColor(EM_LogType logType)
        {
            string displayColor = "green";
            if (logType.ToString().ToLower().Contains("error"))
            {
                displayColor = "red";
            }
            else if (logType.ToString().ToLower().Contains("warn"))
            {
                displayColor = "yellow";
            }
            else
                displayColor = "green";
            return displayColor;
        }

        #endregion: END LOG

        #region: Log System
        public static void Logger_SystemError(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.SYSTEM_ERROR, errorMessage, startUpPath);
        }
        public static void Logger_SystemInfor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.SYSTEM_INFOR, errorMessage, startUpPath);
        }
        public static void Logger_SystemWarn(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.SYSTEM_WARNING, errorMessage, startUpPath);
        }
        #endregion:End Log System

        #region: Black List
        public static void Logger_BlackListInfor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.BLACK_LIST_INFOR, errorMessage, startUpPath);
        }

        #endregion: End Black List


        #region: Log API
        public static void Logger_API_Error(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.API_ERROR, errorMessage, startUpPath);
        }
        public static void Logger_API_Infor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.API_INFOR, errorMessage, startUpPath);
        }
        public static void Logger_API_Warning(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.API_WARNING, errorMessage, startUpPath);
        }
        #endregion: End Log API

        #region: Log COntroller
        public static void Logger_CONTROLLER_Error(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CONTROLLER_ERROR, errorMessage, startUpPath);
        }
        public static void Logger_CONTROLLER_Infor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CONTROLLER_INFOR, errorMessage, startUpPath);
        }
        public static void Logger_CONTROLLER_Warning(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CONTROLLER_WARNING, errorMessage, startUpPath);
        }
        #endregion: End Log Controller


        #region: Log Camera
        public static void Logger_Camera_Error(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CAMERA_ERROR, errorMessage, startUpPath);
        }
        public static void Logger_Camera_Infor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CAMERA_INFOR, errorMessage, startUpPath);
        }
        public static void Logger_Camera_Warning(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.CAMERA_WARNING, errorMessage, startUpPath);
        }
        #endregion: End Log Camera


        #region: Log LPR
        public static void Logger_LPR_Error(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.LPR_ERROR, errorMessage, startUpPath);
        }
        public static void Logger_LPR_Infor(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.LPR_INFOR, errorMessage, startUpPath);
        }
        public static void Logger_LPR_Warning(string errorMessage, string startUpPath)
        {
            Log(EM_LogType.LPR_WARNING, errorMessage, startUpPath);
        }
        #endregion: End Log LPR

        #region: Log Ipc
        public static void Logger_IPC_Error(string errorMessage, string startUpPath, int limitLength)
        {
            string content = GetLogContent(EM_LogType.IPC_INFOR, errorMessage);

            string initPath = startUpPath + $@"\logs\{DateTime.Now.Month}\{DateTime.Now.Day}\";
            initPath += EM_LogType.IPC_INFOR.ToString() + @"\";

            lock (lockObject)
            {
                try
                {
                    Directory.CreateDirectory(initPath);
                    int fCount = Directory.GetFiles(initPath, "*", SearchOption.AllDirectories).Length;
                    if (fCount == 0) fCount = 1;
                    string pathFile = Path.GetDirectoryName(initPath) + @"\" + EM_LogType.IPC_ERROR.ToString() + fCount + ".html";
                    if (!File.Exists(pathFile))
                    {
                        using (StreamWriter writer = new StreamWriter(pathFile, true))
                        {
                            try
                            {
                                writer.WriteLine(content);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        string checkLengthContent = File.ReadAllText(pathFile);
                        if (checkLengthContent.Length >= limitLength)
                        {
                            pathFile = Path.GetDirectoryName(initPath) + @"\" + EM_LogType.IPC_ERROR.ToString() + (fCount + 1) + ".html";
                            using (StreamWriter writer = new StreamWriter(pathFile, true))
                            {
                                try
                                {
                                    writer.WriteLine(content);
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
        public static void Logger_IPC_Infor(string message, string startUpPath, int limitLength)
        {
            string content = GetLogContent(EM_LogType.IPC_INFOR, message);

            string initPath = startUpPath + $@"\logs\{DateTime.Now.Month}\{DateTime.Now.Day}\";
            initPath += EM_LogType.IPC_INFOR.ToString() + @"\";

            lock (lockObject)
            {
                try
                {
                    Directory.CreateDirectory(initPath);
                    int fCount = Directory.GetFiles(initPath, "*", SearchOption.AllDirectories).Length;
                    if (fCount == 0) fCount = 1;
                    string pathFile = Path.GetDirectoryName(initPath) + @"\" + EM_LogType.IPC_INFOR.ToString() + fCount + ".html";
                    if (!File.Exists(pathFile))
                    {
                        using (StreamWriter writer = new StreamWriter(pathFile, true))
                        {
                            try
                            {
                                writer.WriteLine(content);
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        string checkLengthContent = File.ReadAllText(pathFile);
                        if (checkLengthContent.Length >= limitLength)
                        {
                            pathFile = Path.GetDirectoryName(initPath) + @"\" + EM_LogType.IPC_INFOR.ToString() + (fCount + 1) + ".html";
                            using (StreamWriter writer = new StreamWriter(pathFile, true))
                            {
                                try
                                {
                                    writer.WriteLine(content);
                                }
                                catch
                                {
                                }
                            }
                        }
                        else
                        {
                            using (StreamWriter writer = new StreamWriter(pathFile, true))
                            {
                                try
                                {
                                    writer.WriteLine(content);
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
        public static void Logger_IPC_Warning(string errorMessage, string startUpPath, int limitLength)
        {
            Log(EM_LogType.IPC_WARNING, errorMessage, startUpPath);
        }
        #endregion: END Log IPC


        public static FunctionExcecute GetFunctionExcecute()
        {
            StackTrace stackTrace = new StackTrace();
            int skipFunction = 4;
            StackFrame stackFrame = new StackFrame(skipFunction, true);
            MethodBase methodBase = stackFrame.GetMethod();
            return new FunctionExcecute()
            {
                FunctionName = stackFrame.GetMethod().Name,
                FileName = stackFrame.GetFileName(),
                LineNumber = stackFrame.GetFileLineNumber(),
            };
        }

        public class FunctionExcecute
        {
            public string FunctionName { get; set; } = string.Empty;

            public string FileName { get; set; } = string.Empty;

            public int LineNumber { get; set; } = 0;
        }

        public enum EM_LogType
        {
            SYSTEM_INFOR,
            SYSTEM_WARNING,
            SYSTEM_ERROR,
            API_INFOR,
            API_WARNING,
            API_ERROR,
            CAMERA_INFOR,
            CAMERA_WARNING,
            CAMERA_ERROR,
            CONTROLLER_INFOR,
            CONTROLLER_WARNING,
            CONTROLLER_ERROR,
            LPR_INFOR,
            LPR_WARNING,
            LPR_ERROR,
            IPC_INFOR,
            IPC_WARNING,
            IPC_ERROR,
            BLACK_LIST_INFOR,
            Application_Progress,
            CustomerLog
        }
    }
}

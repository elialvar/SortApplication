using System;
using System.Configuration;
using System.IO;
using SortApplication.BussinessLogic.Interfaces;

namespace SortApplication.BussinessLogic
{
    /// <summary>
    /// Class that logs the events of the application to a file.
    /// </summary>
    internal class Logger : ILogger
    {
        private static TextWriter _mWriter;

        /// <inheritdoc />
        public Logger()
        {
            string loggerFolder = ConfigurationManager.AppSettings["LoggerFolder"];
            string fullLoggerLocation = AppDomain.CurrentDomain.BaseDirectory + loggerFolder;

            bool exists = Directory.Exists(fullLoggerLocation);
            if (!exists)
            {
                Directory.CreateDirectory(fullLoggerLocation);
            }

            string fOutput = fullLoggerLocation + "\\log_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".log";
            if (!File.Exists(fOutput))
            {
                _mWriter = TextWriter.Synchronized(new StreamWriter(fOutput, true));
            }
            else
            {
                _mWriter = TextWriter.Synchronized(File.AppendText(fOutput));
            }
        }

        /// <inheritdoc />
        public void WriteLog(string trace)
        {
            WriteTrace(trace);
        }

        /// <inheritdoc />
        public void WriteLog(string trace, Exception ex)
        {
            string str = trace;
            if (ex != null)
            {
                str = str + ": " + ex.Message;
                if (ex.InnerException != null)
                {
                    str = str + Environment.NewLine + "        " + ex.InnerException.Message;
                }
            }
            WriteTrace(str);
        }

        private void WriteTrace(string trace)
        {
            _mWriter.WriteLine(DateTime.Now + ": " + trace);
                
            _mWriter.Flush();
        }
    }
}
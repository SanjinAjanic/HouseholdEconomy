using System;
using System.Collections.Generic;
using System.IO;

namespace HouseholdEconomy.HouseholdLog
{
    /// <summary>
    /// Class that logs eventual errors in the log file. 
    /// </summary>
    public static class ErrorLogger
    {
        public static List<string> ExeceptionList = new List<string>();

        public static string Filename
        {
            get
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var filename = Path.Combine(desktop, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                return filename;
            }
        }

        /// <summary>
        /// Log the text and time to a file on desktop with todays date.
        /// </summary>
        /// <param name="text">The text you want to log in file.</param>
        public static void Log(string text) => File.AppendAllText(Filename, DateTime.Now.ToString("HH:mm") + ": " + text + "\n");

        /// <summary>
        /// Log the exception and time to a file on desktop with todays date.
        /// </summary>
        /// <param name="ex">Exception to be logged</param>
        public static void Log(Exception ex)
        {
            File.AppendAllText(Filename, DateTime.Now.ToString("HH:mm") + ": " + ex.StackTrace + "\r\n" + ex.Message + "\r\n");
        }

        /// <summary>
        /// Logs multiple rows and time to the log file with todays date.
        /// </summary>
        /// <param name="text">List or array of text rows to be logged</param>
        public static void Log(List<string> text)
        {
            File.AppendAllText(Filename, DateTime.Now.ToString("HH:mm") + ":\r\n");
            File.AppendAllLines(Filename, text);
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin_Calculator.Models;

namespace Xamarin_Calculator.Services
{
    /// <summary>
    /// Class to help with saving and reading logs in the calculator's history. Currently, these entries are not saved to the device
    /// and are only accessible in the running instance of the program through which they were saved.
    /// </summary>
    public static class CalcHistoryHelper
    {
        private static List<CalcHistoryEntry> calcHistoryEntries = new List<CalcHistoryEntry>();

        /// <summary>
        /// Method to log a calculator expression.
        /// </summary>
        /// <param name="expression">The expression to log. Please include a standard calculator expression plus " = [RESULT]"</param>
        public static void LogEntry(string expression)
        {
            calcHistoryEntries.Add(new CalcHistoryEntry(expression));
        }


        /// <summary>
        /// Method to retrieve a list of the history entries.
        /// </summary>
        /// <returns></returns>
        public static List<CalcHistoryEntry> ReadHistoryLog()
        {
            return new List<CalcHistoryEntry>(calcHistoryEntries);
        }
    }
}

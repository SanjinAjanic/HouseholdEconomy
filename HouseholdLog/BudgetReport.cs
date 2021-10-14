using HouseholdEconomy.Economy;
using HouseholdEconomy.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace HouseholdEconomy.HouseholdLog
{
    /// <summary>
    /// Class that concatenates the information about the total economy and makes it possible to generate a budget report.
    /// </summary>
    public class BudgetReport
    {
        private static EconomyCalculator ec = new EconomyCalculator();

        private static string Filename
        {
            get
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                var filename = Path.Combine(desktop, DateTime.Now.ToString("yyyy-MM-dd") + "BudgetReport" + ".log");
                return filename;
            }
        }

        /// <summary>
        /// Log the text and time to a file on desktop with todays date.
        /// </summary>
        /// <param name="text">The text you want to log in file.</param>
        public static void GetLog(List<IBalance> income, List<IBalance> expense,
                                                double savedMonthly, List<IBalance> unpaid)
        {
            File.AppendAllText(Filename, $"{Utility.BreakLine} \nBudget Report for: " +
                $"{DateTime.Now.ToString("MMMM")}\n{Utility.BreakLine} \n");

            income.ForEach(i => File.AppendAllText(Filename, $"{i?.Name} {i?.Amount} SEK \n"));
            expense.ForEach(e => File.AppendAllText(Filename, $"{e?.Name} -{e?.Amount} SEK \n"));

            File.AppendAllText(Filename, @$"{Utility.BreakLine}
Monthly balance before savings: {Account.Balance + savedMonthly}
Savings Account:  {Account.Savings}
Savings this month: {savedMonthly} ({Savings.Percentage} %)
Monthly balance after savings: {Account.Balance}
Unpaid bills:");
            unpaid.ForEach(u => File.AppendAllText(Filename, $" {u?.Name} (-{u?.Amount} SEK). "));
            File.AppendAllText(Filename, "\n" + Utility.BreakLine + "\n");
        }
    }
}
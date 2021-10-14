using HouseholdEconomy.HouseholdLog;
using System;

namespace HouseholdEconomy.Economy
{
    /// <summary>
    /// Class for holding a percentage variable. If set to below zero or above 100, Percentage property will be set to zero.
    /// </summary>
    public static class Savings
    {
        /// <summary>
        /// Private field for storing percentage variable.
        /// </summary>
        private static double percentage = 10;

        /// <summary>
        /// Gets percentage variable. Sets percentage variable; if below zero or above 100, set to zero.
        /// </summary>
        public static double Percentage
        {
            get
            {
                return percentage;
            }

            set
            {
                if (value > 100)
                {
                    var PercentageAboveRange = new Exception("The percentage was greater than 100. Percentage set to 0.");
                    ErrorLogger.Log(PercentageAboveRange);
                    ErrorLogger.ExeceptionList.Add(PercentageAboveRange.Message);
                    percentage = 0;
                }
                else if (value < 0)
                {
                    var PercentageBelowRange = new Exception("The percentage was less than 0. Percentage set to 0.");
                    ErrorLogger.Log(PercentageBelowRange);
                    ErrorLogger.ExeceptionList.Add(PercentageBelowRange.Message);
                    percentage = 0;
                }
                else
                {
                    percentage = value;
                }
            }
        }
    }
}
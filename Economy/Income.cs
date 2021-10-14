using System;

namespace HouseholdEconomy
{
    /// <summary>
    /// DTO to hold information about incomes.
    /// </summary>
    public class Income : IBalance
    {
        private double amount = 0;

        /// <summary>
        /// get provides name of income and set sets name of income.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets provides amount of the income.
        /// set sets amount to an absolute value no matter if the sent in value is > 0. If value is non numerical value is set to 0.
        /// </summary>
        public double Amount
        {
            get => amount;
            set
            {
                if (double.IsNaN(value)) amount = 0;
                amount = Math.Abs(value);
            }
        }
        /// <summary>
        /// Sets name to name and amount to amount. 
        /// </summary>
        /// <param name="name">Name of income.</param>
        /// <param name="amount">Income amount.</param>
        public Income(string name, double amount)
        {
            Name = name + ""; // Makes sure name doesn't turn out as null
            Amount = amount;
        }
    }
}
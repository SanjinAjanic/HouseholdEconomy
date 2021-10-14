using System;

namespace HouseholdEconomy
{
    /// <summary>
    /// DTO to hold information about expenses. Expenses are stored in positive values.
    /// </summary>
    public class Expense : IBalance
    {
        private double amount = 0;

        /// <summary>
        /// get provides name of expense and set sets name of expense.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// gets provides amount of the expense.
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
        public Expense(string name, double amount)
        {
            Name = name + ""; // Makes sure name doesn't turn out as null
            Amount = amount;
        }
    }
}
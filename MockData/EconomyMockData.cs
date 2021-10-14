using System.Collections.Generic;

namespace HouseholdEconomy.MockData
{
    /// <summary>
    /// Class for creating economy mock data.
    /// </summary>
    public class EconomyMockData
    {
        /// <summary>
        /// Instantiates List&lt;IBalance&gt; and populates it with object(s) of type Income
        /// </summary>
        /// <returns>List&lt;IBalance&gt;</returns>
        public List<IBalance> GetIncomes()
        {
            return new List<IBalance>() { new Income("salary", 14500) };
        }

        /// <summary>
        /// Instantiates List&lt;IBalance&gt; and populates it with object(s) of type Expense
        /// </summary>
        /// <returns>List&lt;IBalance&gt;</returns>
        public List<IBalance> GetExpenses()
        {
            return new List<IBalance>()
            {
                new Expense("rent", 8900),
                new Expense("netflix", 89),
                new Expense("mobileSubscription", 99),
                new Expense("broadband", 199),
                new Expense("food", 1200),
                new Expense("consumables", 600),
                new Expense("bankFee", 45),
                new Expense("pensionSaving", 1000),
                new Expense("gymSubscription", 1200),
                new Expense("homeInsurance", 75),
            };
        }
    }
}
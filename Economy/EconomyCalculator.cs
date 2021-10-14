using HouseholdEconomy.Economy;
using HouseholdEconomy.HouseholdLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseholdEconomy
{
    /// <summary>
    /// Class that manages all the calculations related to the household economy. 
    /// </summary>
    public class EconomyCalculator
    {
        /// <summary>
        /// A list of all transactions made from balance account.
        /// </summary>
        public List<IBalance> expensesList = new List<IBalance>();

        /// <summary>
        /// A list of incomes that is debit in to balance account.
        /// </summary>
        public List<IBalance> incomeList = new List<IBalance>();

        /// <summary>
        /// How much money is saved every month.
        /// </summary>
        public double SavingMonthly;

        /// <summary>
        /// a list of expenses that didn´t go through because of insufficient funds.
        /// </summary>
        public List<IBalance> unpaidList = new List<IBalance>();

        /// <summary>
        /// Calculate the given procent that should be saved
        /// and then moves the money from balance to savings account.
        /// </summary>
        /// <param name="incomes">List of the incomes</param>
        public void CalculateSavings(List<IBalance> incomes)
        {                   
            double saving = default;
            incomes?.Where(i => i is Income).Where(i => i != null).ToList().ForEach(i => saving += i.Amount * Savings.Percentage / 100);

            Account.Balance -= saving;
            Account.Savings += saving;

            if (saving > 0)
                SavingMonthly = saving;
        }

        /// <summary>
        /// Calculate the transactions of expanses and reduce the balanceaccount.
        /// </summary>
        /// <param name="expenses">A list of expense.</param>
        public void ExpanseCheck(List<IBalance> expenses)
        {
            try
            {
                expenses?.Where(e => e is Expense).Where(e => e != null).ToList().ForEach(e =>
                {
                    if (IsCoverageForTransaction(e))
                        MakeTransaction(e);
                    else
                        InsufficientFunds(e);
                });
            }
            catch (Exception ex)
            {
                LogIt(ex);
            }
        }

        /// <summary>
        /// Calculate the transactions of incomes and increase the balanceaccount.
        /// </summary>
        /// <param name="incomes">A list of income.</param>
        public void IncomeCheck(List<IBalance> incomes)
        {
            try
            {
                incomes?.Where(i => i is Income).Where(i => i != null).ToList().ForEach(i => MakeDeposit(i));
            }
            catch (Exception ex)
            {
                LogIt(ex);
            }
        }

        private static bool IsCoverageForTransaction(IBalance e)
        {
            return Account.Balance >= e?.Amount;
        }

        private static void LogIt(Exception ex)
        {
            ErrorLogger.Log(ex);
            ErrorLogger.ExeceptionList.Add(ex.ToString());
        }

        private void InsufficientFunds(IBalance e)
        {
            var error = new Exception($"The transaction { e?.Name } of { e?.Amount} kr " +
                $"could´t be charged, insufficient funds");

            unpaidList.Add(e);
            LogIt(error);
        }

        private void MakeDeposit(IBalance i)
        {
            Account.Balance += i.Amount;
            incomeList.Add(i);
        }

        private void MakeTransaction(IBalance e)
        {
            Account.Balance -= e.Amount;
            expensesList.Add(e);
        }
    }
}
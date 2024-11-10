using BL.Interfaces;
using Models;
using System.Text;

namespace BL.Implementation
{
    public class OlderClientInterestStrategy : IInterestCalculationStrategy
    {
        public bool MatchesClientAge(int age) => age > 35;

        public LoanDetailsResponse CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest)
        {
            LoanDetailsResponse loanDetails = new();

            if (amount <= 15000)
            {
                loanDetails.BasicInterest = (amount * 0.015m) + (amount * primeInterest / 100); // 1.5% + פריים
            }
            else if (amount > 15000 && amount <= 30000)
            {
                loanDetails.BasicInterest = (amount * 0.03m) + (amount * primeInterest / 100); // 3% + פריים
            }
            else
            {
                loanDetails.BasicInterest = amount * 0.01m; // 1% קבועה
            }

            loanDetails.ExtraInterest = ((periodInMonths - 12) > 0) ? (amount * 0.0015m * (periodInMonths - 12)) : 0;
            loanDetails.TotalAmount = amount + loanDetails.BasicInterest + loanDetails.ExtraInterest;

            return loanDetails;
        }
    }
}

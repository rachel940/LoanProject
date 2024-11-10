using BL.Interfaces;
using Models;
using System.Text;

namespace BL.Implementation
{
    public class MiddleAgedClientInterestStrategy : IInterestCalculationStrategy
    {
        public bool MatchesClientAge(int age) => age >= 20 && age <= 35;

        public LoanDetailsResponse CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest)
        {
            LoanDetailsResponse loanDetails = new();

            if (amount <= 5000)
            {
                loanDetails.BasicInterest = amount * 0.02m;
            }
            else if (amount > 5000 && amount <= 30000)
            {
                loanDetails.BasicInterest = (amount * 0.015m) + (amount * primeInterest / 100);
            }
            else
            {
                loanDetails.BasicInterest = (amount * 0.01m) + (amount * primeInterest / 100);
            }

            loanDetails.ExtraInterest = ((periodInMonths - 12) > 0) ? (amount * 0.0015m * (periodInMonths - 12)) : 0;
            loanDetails.TotalAmount = amount + loanDetails.BasicInterest + loanDetails.ExtraInterest;

            return loanDetails;
        }
    }
}

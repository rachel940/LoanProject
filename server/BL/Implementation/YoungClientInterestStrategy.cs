using BL.Interfaces;
using Models;
using System.Text;

namespace BL.Implementation
{
    public class YoungClientInterestStrategy : IInterestCalculationStrategy
    {
        //Checking whether the client's age is within the appropriate age range for this strategy
        public bool MatchesClientAge(int age) => age < 20;

        public LoanDetailsResponse CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest)
        {
            LoanDetailsResponse loanDetails = new();

            loanDetails.BasicInterest = (amount * 0.02m) + (amount * primeInterest / 100);
            loanDetails.ExtraInterest = ((periodInMonths - 12) > 0) ? (amount * 0.0015m * (periodInMonths - 12)) : 0;
            loanDetails.TotalAmount = amount + loanDetails.BasicInterest + loanDetails.ExtraInterest;

            return loanDetails;
        }
    }
}

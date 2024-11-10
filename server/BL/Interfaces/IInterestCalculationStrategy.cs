using Models;

namespace BL.Interfaces
{
    public interface IInterestCalculationStrategy
    {
        LoanDetailsResponse CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest);
        bool MatchesClientAge(int age);
    }
}

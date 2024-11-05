namespace BL.Interfaces
{
    public interface IInterestCalculationStrategy
    {
        string CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest);
        bool MatchesClientAge(int age);
    }
}

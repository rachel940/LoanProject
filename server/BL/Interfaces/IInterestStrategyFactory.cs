namespace BL.Interfaces
{
    public interface IInterestStrategyFactory
    {
        IInterestCalculationStrategy CreateStrategy(int age);
    }
}

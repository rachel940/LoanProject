using BL.Interfaces;
using System.Text;

namespace BL.Implementation
{
    public class YoungClientInterestStrategy : IInterestCalculationStrategy
    {
        //Checking whether the client's age is within the appropriate age range for this strategy
        public bool MatchesClientAge(int age) => age < 20;

        public string CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest)
        {
            decimal basicInterest = (amount * 0.02m) + (amount * primeInterest / 100);
            decimal extraInterest = ((periodInMonths - 12) > 0) ? (amount * 0.0015m * (periodInMonths - 12)) : 0;
            decimal totalAmount = amount + basicInterest + extraInterest;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ריבית ההלוואה הבסיסית: {basicInterest:C}");

            // Checking if there is additional interest for the additional months and added if necessary
            if (periodInMonths > 12)
            {
                sb.AppendLine($"ריבית לחודשים הנוספים: {extraInterest:C}");
            }

            // הוספת הסכום הכולל
            sb.Append($"הסכום הכולל: {totalAmount:C}");

            return sb.ToString();
        }
    }
}

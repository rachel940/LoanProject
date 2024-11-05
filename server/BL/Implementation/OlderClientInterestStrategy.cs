using BL.Interfaces;
using System.Text;

namespace BL.Implementation
{
    public class OlderClientInterestStrategy : IInterestCalculationStrategy
    {
        public bool MatchesClientAge(int age) => age > 35;

        public string CalculateTotalAmount(decimal amount, int periodInMonths, decimal primeInterest)
        {
            decimal basicInterest;

            if (amount <= 15000)
            {
                basicInterest = (amount * 0.015m) + (amount * primeInterest / 100); // 1.5% + פריים
            }
            else if (amount > 15000 && amount <= 30000)
            {
                basicInterest = (amount * 0.03m) + (amount * primeInterest / 100); // 3% + פריים
            }
            else
            {
                basicInterest = amount * 0.01m; // 1% קבועה
            }

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

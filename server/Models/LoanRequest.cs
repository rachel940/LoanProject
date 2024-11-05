namespace Models
{
    public class LoanRequest
    {
        public string ClientId { get; set; }
        public decimal Amount { get; set; }
        public int PeriodInMonths { get; set; }
    }
}

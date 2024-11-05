using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILoanRepository
    {
        Task<string> ReadFromJsonFile();
        Task WriteToJsonFile(string clients);
    }
}

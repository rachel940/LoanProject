using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class LoanRepository : ILoanRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string FilePath;
        public LoanRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            FilePath = _configuration.GetSection("FilePath").Value;
        }
        //Read all text from json file
        public async Task<string> ReadFromJsonFile()
        {
            try
            {
                return await File.ReadAllTextAsync(FilePath);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while reading the data from file.", ex);
            }
        }
        //Write all text to json file
        public async Task WriteToJsonFile(string clients)
        {
            try
            {
                await File.WriteAllTextAsync(FilePath, clients);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while writing the data into file.", ex);
            }
        }
    }
}

using BL.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BL.Implementation
{
    public class LoanService : ILoanService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoanRepository _loanRepository;
        private readonly IInterestStrategyFactory _strategyFactory;
        private readonly decimal _primeInterest;

        public LoanService(ILoanRepository loanRepository, IInterestStrategyFactory strategyFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _loanRepository = loanRepository;
            _strategyFactory = strategyFactory;
            _primeInterest = decimal.Parse(_configuration.GetSection("PrimeInterest").Value);
        }

        //Get client by clientId saved from file
        public async Task<Client> GetClientById(string clientId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clientId))
                    throw new ArgumentNullException(nameof(clientId));

                var clients = await GetData();
                if (clients != null && clients.Any())
                {
                    var client = clients.Where(x => x.ClientId == clientId).FirstOrDefault();
                    return client;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting client by clientId", ex);
            }
        }

        //Calculating total amount of loan
        public async Task<string> CalculateTotalAmount(LoanRequest loanRequest)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(loanRequest);

                var client = await GetClientById(loanRequest.ClientId) ?? throw new Exception("ClientId is not exists");
                var strategy = _strategyFactory.CreateStrategy(client.Age);
                var totalAmount = strategy.CalculateTotalAmount(loanRequest.Amount, loanRequest.PeriodInMonths, _primeInterest);
                return totalAmount;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LoanService.CalculateTotalAmount", ex);
            }
        }

        //Create new client
        public async Task CreateClient(Client client)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(client);

                var clients = await GetData();
                if (clients != null && clients.Any())
                {
                    var clientExist = clients.Where(x => x.ClientId == client.ClientId).FirstOrDefault();
                    if (clientExist != null)
                    {
                        throw new Exception("Client is already exist");
                    }
                }
                clients.Add(client);
                await WriteData(clients);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in LoanService.CreateClient", ex);
            }
        }

        //Get data saved from file
        private async Task<List<Client>> GetData()
        {
            try
            {
                var data = await _loanRepository.ReadFromJsonFile();
                if (string.IsNullOrWhiteSpace(data))
                {
                    throw new Exception("There are no saved clients");
                }

                return JsonSerializer.Deserialize<List<Client>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving clients from file", ex);
            }
        }

        //Write all clients to file
        private async Task WriteData(List<Client> clients)
        {
            try
            {
                if (clients != null)
                    await _loanRepository.WriteToJsonFile(JsonSerializer.Serialize<List<Client>>(clients));
            }
            catch (Exception ex)
            {
                throw new Exception("Error writing clients into the file", ex);
            }
        }
    }
}

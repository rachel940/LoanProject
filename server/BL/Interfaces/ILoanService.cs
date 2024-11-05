﻿using Models;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ILoanService
    {
        Task<Client> GetClientById(string clientId);
        Task<string> CalculateTotalAmount(LoanRequest loanRequest);
        Task CreateClient(Client client);
    }
}
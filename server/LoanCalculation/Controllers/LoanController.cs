﻿using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using System.Threading.Tasks;

namespace LoanCalculation.Controllers
{
    [Produces("application/json")]
    [Route("loanCalculation/[controller]/[Action]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        public async Task<ActionResult<LoanDetailsResponse>> CalculateLoan([FromBody] LoanRequest request)
        {
            try
            {
                var response = await _loanService.CalculateTotalAmount(request);

                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(response);

                return StatusCode((int)response.StatusCode, response);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "An error occurred while processing calculate loan.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] Client request)
        {
            try
            {
                await _loanService.CreateClient(request);

                return Ok("Client created successfully");
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing CreateClient.");
            }
        }
    }
}

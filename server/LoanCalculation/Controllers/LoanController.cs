using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        public async Task<ActionResult<string>> CalculateLoan([FromBody] LoanRequest request)
        {
            try
            {
                string result = await _loanService.CalculateTotalAmount(request);

                if (!string.IsNullOrWhiteSpace(result))
                    return Ok(result);

                return BadRequest();
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing CalculateLoan.");
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

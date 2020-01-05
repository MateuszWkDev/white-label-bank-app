using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionService;

        public TransactionController(ITransactionAppService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("all-for-user")]
        [ProducesResponseType(typeof(IEnumerable<TransactionDTO>), 200)]
        public async Task<IActionResult> GetAllForUser()
        {
            return Ok(await _transactionService.GetTransactionsForUserAsync(int.Parse(Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPost("perform")]
        public async Task<IActionResult> Perform(TransactionDTO transaction)
        {
            if (transaction == null)
            {
                return BadRequest(new { message = "Transaction is null" });
            }

            transaction.UserId = int.Parse(Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            await _transactionService.PerformTransactionAsync(transaction);
            return Ok();
        }
    }
}
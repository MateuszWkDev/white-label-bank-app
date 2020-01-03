using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionService;

        public TransactionController(ITransactionAppService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<TransactionDTO>), 200)]
        public async Task<IActionResult> GetAllForUser(int userId)
        {
            return Ok(await _transactionService.GetTransactionsForUserAsync(userId).ConfigureAwait(false));
        }

        [HttpPost("perform")]
        public async Task<IActionResult> Perform(TransactionDTO transaction)
        {
            await _transactionService.PerformTransactionAsync(transaction).ConfigureAwait(false);
            return Ok();
        }
    }
}
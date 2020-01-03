using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountService;

        public AccountController(IAccountAppService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<AccountDTO>), 200)]
        public async Task<IActionResult> GetForUser(int userId)
        {
            return Ok(await _accountService.GetAccountsForUserAsync(userId).ConfigureAwait(false));
        }
    }
}
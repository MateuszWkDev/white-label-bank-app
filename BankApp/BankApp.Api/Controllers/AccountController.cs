using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountService;

        public AccountController(IAccountAppService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("all-for-user")]
        [ProducesResponseType(typeof(IEnumerable<AccountDTO>), 200)]
        public async Task<IActionResult> GetForUser()
        {
            return Ok(await _accountService.GetAccountsForUserAsync(int.Parse(Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)).ConfigureAwait(false));
        }
    }
}
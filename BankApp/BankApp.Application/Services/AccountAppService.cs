using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;

namespace BankApp.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountService _accountService;

        public AccountAppService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsForUserAsync(int userId)
        {
            var accountsIds = await _accountService.GetAccountsForUserAsync(userId).ConfigureAwait(false);
            var getAccountTasks = accountsIds.Select(id => _accountService.GetAccountAsync(id));
            return (await Task.WhenAll(getAccountTasks.ToArray()).ConfigureAwait(false)).Select(accountContract => new AccountDTO
            {
                Balance = accountContract.Balance,
                Id = accountContract.Id,
                Name = accountContract.Name,
                Number = accountContract.Number,
                UserId = accountContract.UserId,
            });
        }
    }
}

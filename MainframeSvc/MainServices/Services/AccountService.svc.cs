using System.Collections.Generic;
using Mainframe.Data.Interfaces;

namespace MainServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDbService _accountDbService;

        public AccountService(IAccountDbService accountDbService)
        {
            _accountDbService = accountDbService;
        }

        public AccountContract GetAccount(int id)
        {
            var account = _accountDbService.GetAccount(id);
            return new AccountContract()
            {
                Id = account.Id,
                UserId = account.UserId,
                Name = account.Name,
                Number = account.Number,
                Balance = account.Balance,
            };
        }

        public List<int> GetAccountsForUser(int userId)
        {
            return _accountDbService.GetAccountsForUser(userId);
        }
    }
}

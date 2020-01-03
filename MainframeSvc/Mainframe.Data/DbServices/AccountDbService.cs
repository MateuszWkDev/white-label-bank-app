using System.Collections.Generic;
using System.Linq;
using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;

namespace Mainframe.Data.DbServices
{
    public class AccountDbService : BaseDbService, IAccountDbService
    {
        public AccountDbService(MainframeContext dbContext)
            : base(dbContext)
        {
        }

        public List<int> GetAccountsForUser(int userId)
        {
            return MainframeContext.Accounts.Where(account => account.UserId == userId).Select(account => account.Id).ToList();
        }

        public Account GetAccount(int id)
        {
            return MainframeContext.Accounts.Find(id);
        }
    }
}

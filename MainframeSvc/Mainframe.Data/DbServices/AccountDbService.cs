using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mainframe.Data.DbServices
{
    public class AccountDbService : BaseDbService, IAccountDbService
    {
        public AccountDbService(MainframeContext dbContext) : base(dbContext)
        {

        }

        public List<int> GetAccountsForUser(int userId)
        {
            return _mainframeContext.Accounts.Where(account => account.UserId == userId).Select(account => account.Id).ToList();
        }

        public Account GetAccount(int id)
        {
            return _mainframeContext.Accounts.Find(id);
        }
    }
}

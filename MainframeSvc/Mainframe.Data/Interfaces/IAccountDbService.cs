using System.Collections.Generic;
using Mainframe.Data.Models;

namespace Mainframe.Data.Interfaces
{
    public interface IAccountDbService
    {
        Account GetAccount(int id);

        List<int> GetAccountsForUser(int userId);
    }
}
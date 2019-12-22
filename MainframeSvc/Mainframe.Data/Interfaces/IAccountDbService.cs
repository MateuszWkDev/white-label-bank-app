using Mainframe.Data.Models;
using System.Collections.Generic;

namespace Mainframe.Data.Interfaces
{
    public interface IAccountDbService
    {
        Account GetAccount(int id);
        List<int> GetAccountsForUser(int userId);
    }
}
namespace Mainframe.Data.Interfaces
{
    using System.Collections.Generic;
    using Mainframe.Data.Models;

    public interface IAccountDbService
    {
        Account GetAccount(int id);

        List<int> GetAccountsForUser(int userId);
    }
}
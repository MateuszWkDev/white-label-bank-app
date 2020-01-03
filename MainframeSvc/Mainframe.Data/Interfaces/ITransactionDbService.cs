using System.Collections.Generic;
using Mainframe.Data.Models;

namespace Mainframe.Data.Interfaces
{
    public interface ITransactionDbService
    {
        List<Transaction> GetTransactionsForUser(int userId);

        void PerformTransaction(Transaction transaction);
    }
}
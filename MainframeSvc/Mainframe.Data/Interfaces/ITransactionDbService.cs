using Mainframe.Data.Models;
using System.Collections.Generic;

namespace Mainframe.Data.Interfaces
{
    public interface ITransactionDbService
    {
        List<Transaction> GetTransactionsForUser(int userId);
        void PerformTransaction(Transaction transaction);
    }
}
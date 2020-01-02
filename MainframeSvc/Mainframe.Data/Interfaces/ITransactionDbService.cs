namespace Mainframe.Data.Interfaces
{
    using System.Collections.Generic;
    using Mainframe.Data.Models;

    public interface ITransactionDbService
    {
        List<Transaction> GetTransactionsForUser(int userId);

        void PerformTransaction(Transaction transaction);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;

namespace Mainframe.Data.DbServices
{
    public class TransactionDbService : BaseDbService, ITransactionDbService
    {
        public TransactionDbService(MainframeContext dbContext)
            : base(dbContext)
        {
        }

        public List<Transaction> GetTransactionsForUser(int userId)
        {
            return MainframeContext.Transactions.Where(transaction => transaction.UserId == userId).ToList();
        }

        public void PerformTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException($"Argument is null: {nameof(transaction)}");
            }

            var fromAccount = MainframeContext.Accounts.Find(transaction.FromAccountId);
            var toAccount = MainframeContext.Accounts.Find(transaction.ToAccountId);
            fromAccount.Balance -= transaction.Amount;
            toAccount.Balance += transaction.Amount;
            MainframeContext.Transactions.Add(transaction);
            MainframeContext.SaveChanges();
        }
    }
}

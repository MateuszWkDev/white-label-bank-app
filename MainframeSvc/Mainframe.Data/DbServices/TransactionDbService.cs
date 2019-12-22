using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mainframe.Data.DbServices
{
    public class TransactionDbService : BaseDbService, ITransactionDbService
    {
        public TransactionDbService(MainframeContext dbContext) : base(dbContext)
        {

        }

        public List<Transaction> GetTransactionsForUser(int userId)
        {
            return _mainframeContext.Transactions.Where(transaction => transaction.UserId == userId).ToList();
        }

        public void PerformTransaction(Transaction transaction)
        {
            var fromAccount = _mainframeContext.Accounts.Find(transaction.FromAccountId);
            var toAccount = _mainframeContext.Accounts.Find(transaction.ToAccountId);
            fromAccount.Balance -= transaction.Amount;
            toAccount.Balance += transaction.Amount;
            _mainframeContext.Transactions.Add(transaction);
            _mainframeContext.SaveChanges();
        }
    }
}

using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransactionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TransactionService.svc or TransactionService.svc.cs at the Solution Explorer and start debugging.
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionDbService _transactionDbService;
        public TransactionService(ITransactionDbService transactionDbService)
        {
            _transactionDbService = transactionDbService;
        }

        public List<TransactionContract> GetTransactionsForUser(int userId)
        {
            var transactions = _transactionDbService.GetTransactionsForUser(userId);
            return transactions.Select(transaction => new TransactionContract
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                FromAccountId = transaction.FromAccountId,
                ToAccountId = transaction.ToAccountId,
                UserId = transaction.UserId,
            }).ToList();
        }

        public void PerformTransaction(TransactionContract transaction)
        {
            _transactionDbService.PerformTransaction(new Transaction
            {
                Amount = transaction.Amount,
                FromAccountId = transaction.FromAccountId,
                ToAccountId = transaction.ToAccountId,
                UserId = transaction.UserId,
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;

namespace MainServices.Services
{
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
            if (transaction == null)
            {
                throw new ArgumentException($"Argument is null: {nameof(transaction)}");
            }

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

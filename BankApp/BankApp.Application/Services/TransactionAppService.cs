using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using TransactionService;

namespace BankApp.Application.Services
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly ITransactionService _transactionService;

        public TransactionAppService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsForUserAsync(int userId)
        {
            var transactions = await _transactionService.GetTransactionsForUserAsync(userId).ConfigureAwait(false);
            return transactions.Select(transaction => new TransactionDTO
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                FromAccountId = transaction.FromAccountId,
                ToAccountId = transaction.ToAccountId,
                UserId = transaction.UserId,
            });
        }

        public async Task PerformTransactionAsync(TransactionDTO transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentException($"Argument is null: {nameof(transaction)}");
            }

            await _transactionService.PerformTransactionAsync(new TransactionContract
            {
                Amount = transaction.Amount,
                FromAccountId = transaction.FromAccountId,
                ToAccountId = transaction.ToAccountId,
                UserId = transaction.UserId,
            }).ConfigureAwait(false);
        }
    }
}

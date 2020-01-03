using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Application.Models;

namespace BankApp.Application.Interfaces
{
    public interface ITransactionAppService
    {
        Task<IEnumerable<TransactionDTO>> GetTransactionsForUserAsync(int userId);

        Task PerformTransactionAsync(TransactionDTO transaction);
    }
}

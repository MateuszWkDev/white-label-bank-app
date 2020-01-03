using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Application.Models;

namespace BankApp.Application.Interfaces
{
    public interface IAccountAppService
    {
        /// <summary>
        /// Ilustrates how ca we combine information from mainframe to create endpoint with new information.
        /// </summary>
        /// <param name="userId">Id of the user. </param>
        /// <returns>List of user's accounts. </returns>
        Task<IEnumerable<AccountDTO>> GetAccountsForUserAsync(int userId);
    }
}

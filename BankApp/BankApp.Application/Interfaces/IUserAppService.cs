using System.Threading.Tasks;
using BankApp.Application.Models;

namespace BankApp.Application.Interfaces
{
    public interface IUserAppService
    {
        /// <summary>
        /// Ilustrates how ca we combine information from mainframe to create endpoint with new information.
        /// </summary>
        /// <param name="login">User's login.</param>
        /// <param name="password">User's password.</param>
        /// <returns>User's data.</returns>
        Task<UserDTO> AuthenticateUserAsync(string login, string password);
    }
}

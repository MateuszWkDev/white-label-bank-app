using System;
using System.Threading.Tasks;
using BankApp.Application.Interfaces;
using BankApp.Application.Models;
using UserService;

namespace BankApp.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDTO> AuthenticateUserAsync(string login, string password)
        {
            var userId = await _userService.AuthenticateUserAsync(login, password).ConfigureAwait(false);
            if (userId == null)
            {
                return null;
            }

            var user = await _userService.GetUserByLoginAsync(login).ConfigureAwait(false);
            return new UserDTO()
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
            };
        }
    }
}

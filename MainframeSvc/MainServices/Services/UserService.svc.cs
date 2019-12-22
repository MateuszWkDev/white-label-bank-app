using Mainframe.Data.Interfaces;

namespace MainServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDbService _userDbService;
        public UserService(IUserDbService userDbService)
        {
            _userDbService = userDbService;
        }

        public UserContract GetUserByLogin(string login)
        {
            var user = _userDbService.GetUserByLogin(login);
            return new UserContract()
            {
                Id = user.Id,
                Login = user.Login,
                Name = user.Name,
            };
        }

    }
}

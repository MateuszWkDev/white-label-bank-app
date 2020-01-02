namespace MainServices.Services
{
    using Mainframe.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUserDbService _userDbService;

        public UserService(IUserDbService userDbService)
        {
            _userDbService = userDbService;
        }

        public int AuthenticateUser(string login, string password)
        {
            return _userDbService.AuthenticateUser(login, password);
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

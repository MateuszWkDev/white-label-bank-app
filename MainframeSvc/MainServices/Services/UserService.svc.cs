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
        public void AddUser(string name)
        {
            _userDbService.AddUser(name);
        }

        public int GetUserCount()
        {
            return _userDbService.GetUserCount();
        }
    }
}

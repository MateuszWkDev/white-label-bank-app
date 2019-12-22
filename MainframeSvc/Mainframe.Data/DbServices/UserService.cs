using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;
using System.Linq;

namespace Mainframe.Data.DbServices
{
    public class UserDbService : BaseDbService, IUserDbService
    {
        public UserDbService(MainframeContext dbContext): base(dbContext)
        {

        }

        public int AuthenticateUser(string login, string password)
        {
            return _mainframeContext.Users.Where(user => user.Login == login && user.Password == password).Single().Id;
        }

        public User GetUserByLogin(string login)
        {
            return _mainframeContext.Users.Where(user => user.Login == login).SingleOrDefault();
        }
    }
}

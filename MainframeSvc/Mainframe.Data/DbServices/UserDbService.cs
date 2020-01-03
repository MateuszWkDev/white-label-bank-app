using System.Linq;
using Mainframe.Data.Interfaces;
using Mainframe.Data.Models;

namespace Mainframe.Data.DbServices
{
    public class UserDbService : BaseDbService, IUserDbService
    {
        public UserDbService(MainframeContext dbContext)
            : base(dbContext)
        {
        }

        public int? AuthenticateUser(string login, string password)
        {
            return MainframeContext.Users.Where(user => user.Login == login && user.Password == password).SingleOrDefault()?.Id;
        }

        public User GetUserByLogin(string login)
        {
            return MainframeContext.Users.Where(user => user.Login == login).SingleOrDefault();
        }
    }
}

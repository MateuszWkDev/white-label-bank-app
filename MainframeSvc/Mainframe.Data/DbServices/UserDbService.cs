namespace Mainframe.Data.DbServices
{
    using System.Linq;
    using Mainframe.Data.Interfaces;
    using Mainframe.Data.Models;

    public class UserDbService : BaseDbService, IUserDbService
    {
        public UserDbService(MainframeContext dbContext)
            : base(dbContext)
        {
        }

        public int AuthenticateUser(string login, string password)
        {
            return MainframeContext.Users.Where(user => user.Login == login && user.Password == password).Single().Id;
        }

        public User GetUserByLogin(string login)
        {
            return MainframeContext.Users.Where(user => user.Login == login).SingleOrDefault();
        }
    }
}

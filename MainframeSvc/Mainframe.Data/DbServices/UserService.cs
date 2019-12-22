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
        public void AddUser(string name)
        {
            _mainframeContext.Users.Add(new User()
            {
                Name = name
            });
            _mainframeContext.SaveChanges();
        }

        public int GetUserCount()
        {
            return _mainframeContext.Users.Count();
        }
    }
}

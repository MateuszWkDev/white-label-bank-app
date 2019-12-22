using Mainframe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mainframe.Data.DbServices
{
    public class UserDbService: BaseDbService
    {
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

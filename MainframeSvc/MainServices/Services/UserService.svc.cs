using Mainframe.Data;
using Mainframe.Data.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MainServices.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private readonly UserDbService _userDbService;
        public UserService()
        {
            _userDbService = new UserDbService();
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

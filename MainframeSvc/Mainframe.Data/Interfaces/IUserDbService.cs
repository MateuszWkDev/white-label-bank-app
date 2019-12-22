using Mainframe.Data.Models;

namespace Mainframe.Data.Interfaces
{
    public interface IUserDbService
    {
        User GetUserByLogin(string login);
        int AuthenticateUser(string login, string password);
    }
}
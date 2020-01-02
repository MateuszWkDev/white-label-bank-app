namespace Mainframe.Data.Interfaces
{
    using Mainframe.Data.Models;

    public interface IUserDbService
    {
        User GetUserByLogin(string login);

        int AuthenticateUser(string login, string password);
    }
}
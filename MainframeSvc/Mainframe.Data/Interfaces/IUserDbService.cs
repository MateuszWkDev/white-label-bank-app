namespace Mainframe.Data.Interfaces
{
    public interface IUserDbService
    {
        void AddUser(string name);
        int GetUserCount();
    }
}
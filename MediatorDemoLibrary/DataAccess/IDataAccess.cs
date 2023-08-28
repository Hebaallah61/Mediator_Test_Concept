using MediatorDemoLibrary.Models;

namespace MediatorDemoLibrary.DataAccess
{
    public interface IDataAccess
    {
        UserModel AddUser(string username, string email);
        List<UserModel> Users();
    }
}
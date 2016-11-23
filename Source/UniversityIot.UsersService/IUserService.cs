using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.UsersService
{
    public interface IUserService
    {
        User CreateUser(string username, string password);

        bool DeleteUser(string username);

        User GetUser(string username);
    }
}
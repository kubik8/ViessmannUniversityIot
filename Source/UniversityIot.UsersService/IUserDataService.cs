using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.UsersService
{
    public interface IUserDataService
    {
        User AddUser(User user);

        void DeleteUser(string username);

        User GetUser(string username);
    }
}
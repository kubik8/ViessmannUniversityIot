using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.UsersService
{
    public interface IUserDataService
    {
        User AddUser(User user);

        void DeleteUser(User user);

        User GetUser(string username);
    }
}
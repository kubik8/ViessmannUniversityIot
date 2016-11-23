using System;
using UniversityIot.VitoControlApi.Exceptions;
using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.UsersService
{
    public class UserService : IUserService
    {
        IUserDataService dataService;

        public UserService(IUserDataService dataService)
        {
            this.dataService = dataService;
        }

        public User CreateUser(string username, string password)
        {
            User existingUser = dataService.GetUser(username);

            if (existingUser != null)
                throw new UserAlreadyExistsException();

            User user = new User { Name = username, Password = password };
            user = dataService.AddUser(user);
            return user;
        }

        public bool DeleteUser(string username)
        {
            User existingUser = dataService.GetUser(username);

            if (existingUser == null)
                throw new UserNotFoundException();

            dataService.DeleteUser(existingUser);
            return true;
        }

        public User GetUser(string username)
        {
            User user = dataService.GetUser(username);

            if (user == null)
                throw new UserNotFoundException();

            return user;
        }

    }
}
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
            try
            {
                User user = new User { Name = username, Password = password };
                user = dataService.AddUser(user);
                return user;
            }
            catch (UserServiceException ex)
            {
                throw new UserServiceException("User already exists");
            }
        }

        public bool DeleteUser(string username)
        {
            try
            {
                dataService.DeleteUser(username);
                return true;
            }
            catch (UserServiceException ex)
            {
                throw new UserServiceException("User doesn't exist");
            }
        }

        public User GetUser(string username)
        {
            try
            {
                return dataService.GetUser(username);
            }
            catch(UserServiceException ex)
            {
                throw new UserServiceException("User doesn't exist");
            }
            
        }


    }
}
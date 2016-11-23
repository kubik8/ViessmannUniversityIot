using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.VitoControlApi.Exceptions;
using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.UsersService.Tests
{
    [TestFixture]
    class UserServiceTests
    {
        Mock<IUserDataService> dataServiceMock;
        User user;
        string userDoesNotExistMessage = "User doesn't exist";
        string userAlreadyExistsMessage = "User already exists";

        [OneTimeSetUp]
        public void TestSetup()
        {
            dataServiceMock = new Mock<IUserDataService>();
            user = new User
            {
                Id = 1,
                Name = "Test",
                Password = "Test"
            };
        }

        [Test]
        public void GetUserByName_WhenUserExists_ShouldGetIt()
        {
            dataServiceMock.Setup(x => x.GetUser(user.Name)).Returns(user);
            UserService userService = new UserService(dataServiceMock.Object);

            User resultUser = userService.GetUser(user.Name);

            Assert.AreEqual(user.Id, resultUser.Id);
        }

        [Test]
        public void GetUserByName_WhenUserNotExist_ShouldFail()
        {            
            dataServiceMock.Setup(x => x.GetUser(user.Name)).Throws<UserServiceException>();
            UserService userService = new UserService(dataServiceMock.Object);

            Exception exception = Assert.Throws<UserServiceException>(() => userService.GetUser(user.Name));

            Assert.AreEqual(userDoesNotExistMessage, exception.Message);
        }

        [Test]
        public void CreateUser_WithExistingName_ShouldFail()
        {
            dataServiceMock.Setup(x => x
                .AddUser(It.Is<User>(u => u.Name == user.Name && u.Password == user.Password) ))
                .Throws<UserServiceException>();
            UserService userService = new UserService(dataServiceMock.Object);

            Exception exception = Assert.Throws<UserServiceException>(() => userService.CreateUser(user.Name, user.Password));

            Assert.AreEqual(userAlreadyExistsMessage, exception.Message);
        }

        [Test]
        public void CreateUser_WithNewName_ShouldSuccess()
        {
            dataServiceMock.Setup(x => x
            .AddUser(It.Is<User>(u => u.Name == user.Name && u.Password == user.Password)))
            .Returns(user);
            UserService userService = new UserService(dataServiceMock.Object);

            User resultUser = userService.CreateUser(user.Name, user.Password);

            Assert.AreEqual(user.Id, resultUser.Id);
        }

        [Test]
        public void DeleteUser_WhenUserExists_ShouldFail()
        {
            UserService userService = new UserService(dataServiceMock.Object);

            bool result = userService.DeleteUser(user.Name);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void DeleteUser_WhenUserNotExist_ShouldFail()
        {
            dataServiceMock.Setup(x => x.DeleteUser(user.Name)).Throws<UserServiceException>();
            UserService userService = new UserService(dataServiceMock.Object);

            Exception exception = Assert.Throws<UserServiceException>(() => userService.DeleteUser(user.Name));

            Assert.AreEqual(userDoesNotExistMessage, exception.Message);
        }
    }
}

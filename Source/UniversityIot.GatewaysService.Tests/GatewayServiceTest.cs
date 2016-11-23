using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityIot.VitoControlApi.Models.DataObjects;
using UniversityIot.VitoControlApi.Enums;
using UniversityIot.GatewaysService;

namespace UniversityIot.GatewaysService.Tests
{
    [TestFixture]
    class GatewayServiceTest
    {
        User user;
        Gateway gateway;
        Mock<IGatewayDataService> dataServiceMock;

        [OneTimeSetUp]
        public void TestSetup()
        {
            dataServiceMock = new Mock<IGatewayDataService>();

            gateway = new Gateway
            {
                Id = 1,
                Description = "Test",
                SerialNumber = "0123456789123456",
                Status = GatewayStatus.Unregistered
            };

            user = new User
            {
                Id = 1,
                Name = "Test",
                Password = "Test"
            };
        }

        [Test]
        public void RegisterGateway_WithoutSerialNumber_ShouldCreateNewGatewayAndRegister()
        {

        }

        [Test]
        public void RegisterGateway_ShouldConnectUserWithGatewayAndSetGatewayStatusToRegistered()
        {

        }

        [Test]
        public void RegisterGateway_ShouldNotRegisterTheSameGatewayTwice()
        {

        }

        [Test]
        public void RegisterGateway_WithIncorrectSerialNumber_ShouldFail()
        {

        }

        [Test]
        public void UnregisterGateway_ShouldDisconnectUserWithGatewayAndSetGatewayStatusToUnregistered()
        {

        }

        [Test]
        public void UnregisterNotRegisteredGateway_ShouldFail()
        {

        }

        [Test]
        public void UnregisterNotExistingGateway_ShouldFail()
        {

        }
    }
}

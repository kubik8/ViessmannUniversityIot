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
using UniversityIot.VitoControlApi.Exceptions;

namespace UniversityIot.GatewaysService.Tests
{
    [TestFixture]
    class GatewayServiceTest
    {
        User user;
        Gateway gateway;
        Mock<IGatewayDataService> dataServiceMock;

        [SetUp]
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
            Gateway gatewayWithoutSerialNumber = new Gateway { Description = gateway.Description, Status = GatewayStatus.Unregistered };
            dataServiceMock.Setup(x => x.CreateGateway(gatewayWithoutSerialNumber.Description)).Returns(gateway);
            dataServiceMock.Setup(x => x.Save(gateway)).Returns(gateway);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Gateway resultGateway = gatewayService.RegisterGateway(user, gatewayWithoutSerialNumber);

            Assert.AreEqual(gateway.SerialNumber, resultGateway.SerialNumber);
            Assert.AreEqual(GatewayStatus.Registered, resultGateway.Status);
            Assert.NotNull(resultGateway.User);
        }

        [Test]
        public void RegisterGateway_ShouldConnectUserWithGatewayAndSetGatewayStatusToRegistered()
        {
            dataServiceMock.Setup(x => x.Save(gateway)).Returns(gateway);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Gateway resultGateway = gatewayService.RegisterGateway(user, gateway);

            Assert.AreEqual(gateway.SerialNumber, resultGateway.SerialNumber);
            Assert.AreEqual(GatewayStatus.Registered, resultGateway.Status);
        }

        [Test]
        public void RegisterGateway_ShouldNotRegisterTheSameGatewayTwice()
        {
            dataServiceMock.Setup(x => x.Save(gateway)).Returns(gateway);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            gatewayService.RegisterGateway(user, gateway);

            Assert.Throws<GatewayAlreadyRegisteredException>(() => gatewayService.RegisterGateway(user, gateway));
        }

        [Test]
        public void RegisterGateway_WithTooShortSerialNumber_ShouldFail()
        {
            gateway.SerialNumber = "1234";
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Assert.Throws<IncorrectSerialNumberException>(() => gatewayService.RegisterGateway(user, gateway));
        }

        [Test]
        public void RegisterGateway_WithSerialNumberContainingLetters_ShouldFail()
        {
            gateway.SerialNumber = "abcabcabcabcabca";
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Assert.Throws<IncorrectSerialNumberException>(() => gatewayService.RegisterGateway(user, gateway));
        }

        [Test]
        public void UnregisterGateway_ShouldDisconnectUserWithGatewayAndSetGatewayStatusToUnregistered()
        {
            gateway.Status = GatewayStatus.Registered;
            dataServiceMock.Setup(x => x.GetGateway(gateway.Id)).Returns(gateway);
            dataServiceMock.Setup(x => x.Save(gateway)).Returns(gateway);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Gateway resultGateway = gatewayService.UnregisterGateway(user, gateway.Id);

            Assert.IsNull(resultGateway.User);
            Assert.AreEqual(GatewayStatus.Unregistered, resultGateway.Status);
        }

        [Test]
        public void UnregisterNotRegisteredGateway_ShouldFail()
        {
            dataServiceMock.Setup(x => x.GetGateway(gateway.Id)).Returns(gateway);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Assert.Throws<GatewayUnregisteredException>(() => gatewayService.UnregisterGateway(user, gateway.Id));
        }

        [Test]
        public void UnregisterNotExistingGateway_ShouldFail()
        {
            dataServiceMock.Setup(x => x.GetGateway(gateway.Id)).Returns((Gateway) null);
            GatewayService gatewayService = new GatewayService(dataServiceMock.Object);

            Assert.Throws<GatewayNotFoundException>(() => gatewayService.UnregisterGateway(user, gateway.Id));
        }
    }
}

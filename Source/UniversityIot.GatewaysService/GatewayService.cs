using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityIot.VitoControlApi.Enums;
using UniversityIot.VitoControlApi.Exceptions;
using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.GatewaysService
{
    public class GatewayService : IGatewayService
    {
        IGatewayDataService dataService;
        const int serialNumberRequiredLength = 16; 

        public GatewayService(IGatewayDataService dataService)
        {
            this.dataService = dataService;
        }

        public Gateway RegisterGateway(User user, Gateway gateway)
        {
            if (gateway.Status.Equals(GatewayStatus.Unregistered))
            {
                if (string.IsNullOrEmpty(gateway.SerialNumber))
                    gateway = CreateGateway(gateway.Description);
                else if (gateway.SerialNumber.Length != serialNumberRequiredLength || !gateway.SerialNumber.All(char.IsDigit))
                    throw new IncorrectSerialNumberException("Serial number must contain exactly 16 digits");

                gateway.User = user;
                gateway.Status = GatewayStatus.Registered;
                return dataService.Save(gateway);
            }
            else
                throw new GatewayAlreadyRegisteredException();
        }

        public Gateway UnregisterGateway(User user, int gatewayId)
        {
            Gateway gateway = GetGateway(gatewayId);

            if (gateway == null)
                throw new GatewayNotFoundException();

            if (gateway.Status.Equals(GatewayStatus.Unregistered))
                throw new GatewayUnregisteredException();

            gateway.User = null;
            gateway.Status = GatewayStatus.Unregistered;
            return dataService.Save(gateway);
        }

        public Gateway CreateGateway(string gatewayDescription)
        {
            return dataService.CreateGateway(gatewayDescription);
        }        

        public Gateway GetGateway(int gatewayId)
        {
            Gateway gateway = dataService.GetGateway(gatewayId);

            if (gateway == null)
                throw new GatewayNotFoundException();

            return gateway;
        }
    }
}
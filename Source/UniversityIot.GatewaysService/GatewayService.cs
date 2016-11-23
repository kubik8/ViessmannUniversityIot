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

        public GatewayService(IGatewayDataService dataService)
        {
            this.dataService = dataService;
        }

        public void RegisterGateway(User user, Gateway gateway)
        {
            if (gateway.Status.Equals(GatewayStatus.Unregistered))
            {
                int serialNumber;

                if (string.IsNullOrEmpty(gateway.SerialNumber))
                    gateway = CreateGateway(gateway.Description);
                else if(gateway.SerialNumber.Length != 16 || int.TryParse(gateway.SerialNumber, out serialNumber))
                    throw new GatewayServiceException("Serial number must contain exactly 16 digits");

                user.GatewaysIds.Add(gateway.Id);
                gateway.Status = GatewayStatus.Registered;
                dataService.Update(gateway);
            }
            else
                throw new GatewayServiceException("Gateway is already registered");
        }

        public void UnregisterGateway(User user, int gatewayId)
        {
            Gateway gateway = GetGateway(gatewayId);

            if (gateway.Status.Equals(GatewayStatus.Registered))
            {
                user.GatewaysIds.Remove(gatewayId);
                gateway.Status = GatewayStatus.Unregistered;
                dataService.Update(gateway);
            }
        }

        public Gateway CreateGateway(string gatewayDescription)
        {
            return dataService.CreateGateway(gatewayDescription);
        }        

        public Gateway GetGateway(int gatewayId)
        {
            try
            {
                return dataService.GetGateway(gatewayId);
            }
            catch (GatewayServiceException ex)
            {
                throw new GatewayServiceException("Gateway doesn't exist");
            }
        }
    }
}
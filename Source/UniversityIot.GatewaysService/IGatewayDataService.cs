using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.GatewaysService
{
    public interface IGatewayDataService
    {
        Gateway CreateGateway(string gatewayDescription);
        Gateway GetGateway(int gatewayId);
        void Update(Gateway gateway);
    }
}
using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.GatewaysService
{
    public interface IGatewayService
    {
        void RegisterGateway(User user, Gateway gateway);

        void UnregisterGateway(User user, int gatewayId);
    }
}
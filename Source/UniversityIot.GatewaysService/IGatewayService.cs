using UniversityIot.VitoControlApi.Models.DataObjects;

namespace UniversityIot.GatewaysService
{
    public interface IGatewayService
    {
        Gateway RegisterGateway(User user, Gateway gateway);

        Gateway UnregisterGateway(User user, int gatewayId);
    }
}
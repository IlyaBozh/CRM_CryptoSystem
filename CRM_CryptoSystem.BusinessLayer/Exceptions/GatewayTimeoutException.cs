
namespace CRM_CryptoSystem.BusinessLayer.Exceptions;

public class GatewayTimeoutException : Exception
{
    GatewayTimeoutException(string message) : base(message)
    {
        
    }

}

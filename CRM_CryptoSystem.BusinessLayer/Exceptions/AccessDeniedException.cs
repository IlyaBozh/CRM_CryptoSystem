
namespace CRM_CryptoSystem.BusinessLayer.Exceptions;

public class AccessDeniedException : Exception
{
    public AccessDeniedException(string message) : base(message)
    {

    }
}

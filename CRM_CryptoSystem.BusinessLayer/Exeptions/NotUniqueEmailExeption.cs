
namespace CRM_CryptoSystem.BusinessLayer.Exeptions;

public class NotUniqueEmailExeption : Exception
{
    public NotUniqueEmailExeption(string message) : base(message)
    {

    }
}

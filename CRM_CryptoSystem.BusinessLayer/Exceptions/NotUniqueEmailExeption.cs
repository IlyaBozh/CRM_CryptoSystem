namespace CRM_CryptoSystem.BusinessLayer.Exceptions;

public class NotUniqueEmailExeption : Exception
{
    public NotUniqueEmailExeption(string message) : base(message)
    {

    }
}

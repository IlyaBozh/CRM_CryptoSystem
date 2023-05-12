namespace CRM_CryptoSystem.BusinessLayer.Exceptions;

public class NotUniqueEmailException : Exception
{
    public NotUniqueEmailException(string message) : base(message)
    {

    }
}

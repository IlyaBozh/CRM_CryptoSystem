
namespace CRM_CryptoSystem.BusinessLayer.Infrastructure;

public static class StringExtension
{
    public static string MaskEmail(this string original)
    {
        int index = original.IndexOf('@');
        string output = original;

        if (index > 3)
            output = original.Substring(0, 2) + new string('*', index - 2) + original.Substring(index);
        
        return output;
    }
}

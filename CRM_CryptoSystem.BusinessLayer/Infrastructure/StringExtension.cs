
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

    public static string MaskNumber(this string original)
    {
        string firstFourNumbers = original.Substring(0, 4);
        string theLastTwoNumbers = original.Substring(9, 2);
        string maskedNumber = firstFourNumbers.PadRight(9, '*');
        maskedNumber += theLastTwoNumbers;
        return maskedNumber;
    }

    public static string MaskTheLastFive(this string original)
    {
        string maskedData = original.Remove(original.Length - 5, 5);
        return $"{maskedData} *****";
    }
}

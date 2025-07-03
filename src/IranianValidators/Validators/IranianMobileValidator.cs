using IranianValidators.Providers;
using System.Linq;

namespace IranianValidators.Validators;

internal static class IranianMobileValidator
{
    public static bool IsValid(string? number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return false;

        number = number.Trim();

        if (number.Length != 11 || !number.All(char.IsDigit))
            return false;

        if (!number.StartsWith("09"))
            return false;

        // Check BIN using provider
        var info = MobileInfoProvider.GetInfo(number);

        // Must have a known operator (BIN match successful)
        return info.Operator != "UNKN";
    }
}

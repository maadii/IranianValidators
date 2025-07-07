using IranianValidators.Providers;
using System.Linq;

namespace IranianValidators.Validators;

/// <summary>
/// Provides validation for Iranian postal codes.
/// </summary>
internal static class IranianPostalCodeValidator
{
    public static bool IsValid(string? postalCode)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
            return false;

        postalCode = postalCode.Trim();

        // Must be exactly 10 digits
        if (postalCode.Length != 10 || !postalCode.All(char.IsDigit))
            return false;

        // Reject if all digits are the same (e.g., 1111111111)
        if (postalCode.Distinct().Count() == 1)
            return false;

        // Must have a known BIN (province)
        var info = PostalCodeInfoProvider.GetInfo(postalCode);
        return info.Province != "UNKN";
    }
}

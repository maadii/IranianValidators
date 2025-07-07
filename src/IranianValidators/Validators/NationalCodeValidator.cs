using System.Linq;

namespace IranianValidators.Validators;

internal static class NationalCodeValidator
{
    public static bool IsValid(string? code)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Length != 10)
            return false;

        if (!code.All(char.IsDigit))
            return false;

        // Reject codes with all digits the same (e.g., 0000000000)
        if (code.Distinct().Count() == 1)
            return false;

        var sum = 0;
        for (int i = 0; i < 9; i++)
            sum += int.Parse(code[i].ToString()) * (10 - i);

        var remainder = sum % 11;
        var checkDigit = int.Parse(code[9].ToString());

        return (remainder < 2 && checkDigit == remainder)
            || (remainder >= 2 && checkDigit == 11 - remainder);
    }
}

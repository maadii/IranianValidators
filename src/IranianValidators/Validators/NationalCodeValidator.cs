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

        var repeated = new[]
        {
        "0000000000", "1111111111", "2222222222", "3333333333", "4444444444",
        "5555555555", "6666666666", "7777777777", "8888888888", "9999999999"
    };

        if (repeated.Contains(code))
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
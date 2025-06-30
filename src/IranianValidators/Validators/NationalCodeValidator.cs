using System.Linq;

namespace IranianValidators.Validators;

public static class NationalCodeValidator
{
    public static bool IsValid(string? nationalCode)
    {
        if (string.IsNullOrWhiteSpace(nationalCode))
            return false;

        nationalCode = nationalCode.Trim();

        if (nationalCode.Length != 10 || !nationalCode.All(char.IsDigit))
            return false;

        if (nationalCode.Distinct().Count() == 1)
            return false;

        int check = int.Parse(nationalCode[9].ToString());

        int sum = Enumerable.Range(0, 9)
                            .Select(i => int.Parse(nationalCode[i].ToString()) * (10 - i))
                            .Sum();

        int remainder = sum % 11;
        return (remainder < 2 && check == remainder) || (remainder >= 2 && check == 11 - remainder);
    }
}
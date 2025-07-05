using IranianValidators.Providers;
using System.Text;

namespace IranianValidators.Validators;

internal static class IbanValidator
{
    public static bool IsValid(string? iban)
    {
        if (string.IsNullOrWhiteSpace(iban))
            return false;

        iban = iban.Trim().ToUpper();

        // Step 1: must start with IR and be exactly 26 characters
        if (!iban.StartsWith("IR") || iban.Length != 26)
            return false;

        // Step 2: Extract bank code and check if it's valid
        var bankCode = iban.Substring(4, 3);
        var bankInfo = IbanBankInfoProvider.GetInfo(iban);
        if (bankInfo.Abbreviation == "UNKN")
            return false;

        // Step 3: rearrange
        string rearranged = iban.Substring(4) + iban.Substring(0, 4);

        // Step 4: convert to numeric
        StringBuilder numericIban = new();
        foreach (char ch in rearranged)
        {
            if (char.IsDigit(ch))
                numericIban.Append(ch);
            else if (char.IsLetter(ch))
                numericIban.Append((ch - 'A' + 10).ToString());
            else
                return false;
        }

        // Step 5: mod 97
        string numeric = numericIban.ToString();
        int remainder = 0;
        foreach (char c in numeric)
        {
            remainder = (remainder * 10 + (c - '0')) % 97;
        }

        return remainder == 1;
    }
}

using IranianValidators.Validators;
using IranianValidators.Providers;
using IranianValidators.Models;

namespace IranianValidators.Extensions;

/// <summary>
/// Provides fluent-style extension methods for validating and extracting
/// information from Iranian-specific identifiers such as national codes and bank card numbers.
/// </summary>
public static class IranianStringExtensions
{
    /// <summary>
    /// Checks whether the string is a valid Iranian national code.
    /// </summary>
    public static bool IsIranianNationalCodeValid(this string? input)
    {
        return NationalCodeValidator.IsValid(input);
    }

    /// <summary>
    /// Checks whether the string is a valid Iranian bank card number.
    /// </summary>
    public static bool IsIranianBankCardValid(this string? input)
    {
        return BankCardValidator.IsValid(input);
    }

    /// <summary>
    /// Retrieves bank information (label, abbreviation, etc.) from the card number.
    /// </summary>
    public static BankCardInfo GetIranianBankInfoByCard(this string? cardNumber)
    {
        return BankCardInfoProvider.GetInfo(cardNumber);
    }
}
